using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using WebSocketSharp;
using LitJson;

public class websocket:MonoBehaviour
{
    private WebSocket socket;
    Dictionary<int, Action<int, int, object>> serivces_handler = null;
    proto_type _proto_type;
    bool is_connected = false;
    Queue<byte[]> messageQueue = new Queue<byte[]>();
    public void register_serivces_handler(Dictionary<int, Action<int, int, object>> serviceshandle)
    {
        serivces_handler = serviceshandle;
    }

    public void send_cmd(int stype, int ctype,string body)
    {
        if (this.socket == null || !this.is_connected)
        {
            return;
        }
        byte[] buf = proto_man.Instance().encode_cmd(this._proto_type, stype, ctype, body);
        this.socket.Send(buf);
    }


    void addmsg(byte[] data)
    {
        lock (messageQueue)
        {
            messageQueue.Enqueue(data);
        }
    }

    byte[] removemsg()
    {
        lock (messageQueue)
        {
            return messageQueue.Dequeue();
        }
    }


    void _on_opened(object sender, EventArgs e)
    {
        Debug.Log("ws connect server success");
        this.is_connected = true;
    }

    void _on_recv_data(object sender, MessageEventArgs e)
    {
        if (e.IsBinary)
        {
            byte[] data = e.RawData;
           
            this.addmsg(data);
        }
    }

    void _on_socket_close(object sender, CloseEventArgs e)
    {
        if (this.socket != null)
        {
            this.close();
        }
    }

    void _on_socket_err(object sender, ErrorEventArgs e)
    {
        this.close();
    }

    void close()
    {
        this.is_connected = false;
        if (this.socket != null)
        {
            this.socket.Close();
            this.socket = null;
        }
    }


    public void connect(string url, proto_type type)
    {
        using (socket = new WebSocket(url))
        this._proto_type = type;
        socket.OnOpen += this._on_opened;
        socket.OnMessage += this._on_recv_data;
        socket.OnError += this._on_socket_err;
        socket.OnClose += this._on_socket_close;
        socket.Connect();

    }


    private void Update()
    {
        if (this.messageQueue.Count > 0)
        {
            byte[] data = this.removemsg();
            if (this.serivces_handler == null)
            {
                return;
            }
            ArrayList cmd = proto_man.Instance().decode_cmd(_proto_type,data);
            if (cmd == null)
            {
                return;
            }
            int stype = (int)cmd[0];
            if (this.serivces_handler[stype] != null)
            {
                this.serivces_handler[stype]((int)cmd[0], (int)cmd[1], cmd[2]);
            }

        }
    }
}

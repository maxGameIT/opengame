using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using Master;

public class proto_man 
{
    static proto_man g_instance;
    public static proto_man Instance()
    {
        if (g_instance == null)
        {
            g_instance = new proto_man();
        }
        return g_instance;
    }
    public delegate ArrayList decode(byte[] data);
    public delegate byte[] encode(int stype,int ctype,string body);

    Dictionary<int, decode> decoders = new Dictionary<int, decode>();
    Dictionary<int, encode> encoders = new Dictionary<int, encode>();

    public void init()
    {
        reg_buf_encoder((int)Stype.Auth, (int)Cmd.Auth.GUEST_LOGIN, proto_tool.Instance().encode_str_cmd);
        reg_buf_decoder((int)Stype.Auth, (int)Cmd.Auth.GUEST_LOGIN, auth_proto.decode_guest_login);
        reg_buf_decoder((int)Stype.Auth, (int)Cmd.Auth.RELOGIN, proto_tool.Instance().decode_empty_cmd);

        reg_buf_decoder((int)Stype.Auth, (int)Cmd.Auth.EDIT_PROFILE, auth_proto.decode_edit_profile);
        reg_buf_encoder((int)Stype.Auth, (int)Cmd.Auth.EDIT_PROFILE, auth_proto.encode_edit_profile);

        reg_buf_encoder((int)Stype.Auth, (int)Cmd.Auth.GUEST_UPGRADE_INDENTIFY, auth_proto.encode_upgrade_verify_code);
        reg_buf_decoder((int)Stype.Auth, (int)Cmd.Auth.GUEST_UPGRADE_INDENTIFY, proto_tool.Instance().decode_status_cmd);

        reg_buf_encoder((int)Stype.Auth, (int)Cmd.Auth.BIND_PHONE_NUM, auth_proto.encode_guest_bind_account);
        reg_buf_decoder((int)Stype.Auth, (int)Cmd.Auth.BIND_PHONE_NUM, proto_tool.Instance().decode_status_cmd);

        reg_buf_decoder((int)Stype.Auth, (int)Cmd.Auth.UNAME_LOGIN, auth_proto.decode_uname_login);
        reg_buf_encoder((int)Stype.Auth, (int)Cmd.Auth.UNAME_LOGIN, auth_proto.encode_uname_login);

        reg_buf_encoder((int)Stype.Auth, (int)Cmd.Auth.GET_PHONE_REG_VERIFY, auth_proto.encode_phone_reg_verify_code);
        reg_buf_decoder((int)Stype.Auth, (int)Cmd.Auth.GET_PHONE_REG_VERIFY, proto_tool.Instance().decode_status_cmd);

        reg_buf_encoder((int)Stype.Auth, (int)Cmd.Auth.PHONE_REG_ACCOUNT, auth_proto.encode_phone_reg_account);
        reg_buf_decoder((int)Stype.Auth, (int)Cmd.Auth.PHONE_REG_ACCOUNT, proto_tool.Instance().decode_status_cmd);

        reg_buf_encoder((int)Stype.Auth, (int)Cmd.Auth.GET_FORGET_PWD_VERIFY, auth_proto.encode_phone_reg_verify_code);
        reg_buf_decoder((int)Stype.Auth, (int)Cmd.Auth.GET_FORGET_PWD_VERIFY, proto_tool.Instance().decode_status_cmd);

        reg_buf_encoder((int)Stype.Auth, (int)Cmd.Auth.RESET_USER_PWD, auth_proto.encode_reset_upwd);
        reg_buf_decoder((int)Stype.Auth, (int)Cmd.Auth.RESET_USER_PWD, proto_tool.Instance().decode_status_cmd);
    }



    public object encrypt_cmd(object str_or_buf)
    {
        return str_or_buf;
    }

    public object decrypt_cmd(object str_or_buf)
    {
        return str_or_buf;
    }

    public byte[] encode_cmd(proto_type proto_Type, int stype,int ctype,string body)
    {
        byte[] cmd = null;
        if (proto_Type == proto_type.JSON)
        {
            cmd = this._json_encode(stype,ctype,body);
        }
        else
        {
            int key = this.get_key(stype,ctype);
            if (!this.encoders.ContainsKey(key))
            {
                return null;
            }
           cmd = this.encoders[key](stype,ctype, body);
        }
        proto_tool.Instance().write_prototype_inbuf(cmd,proto_Type);
        if (cmd != null)
        {
            cmd = (byte[])this.encrypt_cmd(cmd);
        }
        return cmd;
    }

    public ArrayList decode_cmd(proto_type proto_Type, byte[] str_or_buf)
    {
        str_or_buf = (byte[])decrypt_cmd(str_or_buf);
        ArrayList cmd = null;
        if (str_or_buf.Length < proto_tool.Instance().header_size)
        {
            return null;
        }

        if (proto_Type == proto_type.JSON)
        {
            return this._json_decode(str_or_buf);
        }
        int stype = proto_tool.Instance().read_int16(str_or_buf, 0);
        int ctype = proto_tool.Instance().read_int16(str_or_buf, 2);
        int key = this.get_key(stype,ctype);
        if (!this.decoders.ContainsKey(key))
        {
            return null;
        }
        cmd = this.decoders[key](str_or_buf);
        return cmd;
    }


    byte[] _json_encode(int stype, int ctype,object body)
    {
        ArrayList cmd = new ArrayList();
        cmd.Add(body);
        string str = JsonMapper.ToJson(cmd);
        byte[] cmd_buf = proto_tool.Instance().encode_str_cmd(stype, ctype, str);
        return cmd_buf;
    }

    ArrayList _json_decode(byte[] cmd_buf)
    {
        ArrayList cmd = proto_tool.Instance().decode_str_cmd(cmd_buf);
        string cmd_json = (string)cmd[2];
        try
        {
            JsonData bodyset = JsonMapper.ToObject(cmd_json);
            cmd[2] = bodyset;
        }
        catch 
        {
            return null;
        }
        if (cmd == null)
        {
            return null;
        }
        if (cmd.Count == 0)
        {
            return null;
        }
        if (cmd.Count > 0 && cmd.Count < 2)
        {
            if (cmd[0] == null)
            {
                return null;
            }
        }
        else if (cmd.Count >= 2 && cmd.Count < 3)
        {
            if (cmd[1] == null)
            {
                return null;
            }
        }
        else if (cmd.Count >= 3)
        {
            if ( cmd[2] == null)
            {
                return null;
            }
        }
        return cmd;

    }


    public int get_key(int stype,int ctype)
    {
        return (stype * 65536 + ctype);
    }

    public void reg_buf_encoder(int stype, int ctype,encode encode_func)
    {
        int key = get_key(stype, ctype);
        if (encoders.ContainsKey(key))
        {
            Debug.LogError("stype: " + stype + " ctype: " + ctype + "is reged!!!");
            encoders[key] = encode_func;
        }
        else
        {
            encoders.Add(key, encode_func);
        }
    }

    public void reg_buf_decoder(int stype, int ctype,decode decode_func)
    {
        var key = get_key(stype, ctype);
        if (decoders.ContainsKey(key))
        { // 已经注册过了，是否搞错了
            Debug.LogError("stype: " + stype + " ctype: " + ctype + "is reged!!!");
            decoders[key] = decode_func;
        }
        else
        {
            decoders.Add(key, decode_func);
        }
    }
}

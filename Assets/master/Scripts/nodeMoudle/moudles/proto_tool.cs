using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum proto_type
{
    JSON = 1,
    BUF = 2
}


public class proto_tool
{
    static proto_tool g_instance;
    public static proto_tool Instance()
    {
        if (g_instance == null)
        {
            g_instance = new proto_tool();
        }
        return g_instance;
    }
    public readonly int header_size = 10;

    public byte[] alloc_Buffer(int totallen)
    {
        return new byte[totallen];
    }

    public int read_int16(byte[] cmd_buf, int offset)
    {
        //if (BitConverter.IsLittleEndian)
        //{
        //    Array.Reverse(cmd_buf);
        //}
        return BitConverter.ToInt16(cmd_buf,offset);
    }

    public byte[] write_int16(byte[] cmd_buf,int offset,short value)
    {
        byte[] result = BitConverter.GetBytes(value);
        //if (BitConverter.IsLittleEndian)
        //{
        //    ////Array.Reverse(result);
        //}
        Buffer.BlockCopy(result,0,cmd_buf,offset, result.Length);
        return cmd_buf;
    }

    public int read_int32(byte[] cmd_buf, int offset)
    {
        //if (BitConverter.IsLittleEndian)
        //{
        //   // Array.Reverse(cmd_buf);
        //}
        return BitConverter.ToInt32(cmd_buf, offset);
    }

    public byte[] write_int32(byte[] cmd_buf, int offset, int value)
    {
        byte[] result = BitConverter.GetBytes(value);
        //if (BitConverter.IsLittleEndian)
        //{
        //    //Array.Reverse(result);
        //}

        Buffer.BlockCopy(result, 0, cmd_buf, offset, result.Length);
        return cmd_buf;
    }

    public uint read_uint32(byte[] cmd_buf, int offset)
    {
        //if (BitConverter.IsLittleEndian)
        //{
        //    Array.Reverse(cmd_buf);
        //}
        return BitConverter.ToUInt32(cmd_buf, offset);
    }


    public byte[] write_uint32(byte[] cmd_buf, int offset, uint value)
    {
        byte[] result = BitConverter.GetBytes(value);
        //if (BitConverter.IsLittleEndian)
        //{
        //    //Array.Reverse(result);
        //}
        Buffer.BlockCopy(result, 0, cmd_buf, offset, result.Length);
        return cmd_buf;
    }

    public float read_float(byte[] cmd_buf, int offset)
    {
        //if (BitConverter.IsLittleEndian)
        //{
        //    Array.Reverse(cmd_buf);
        //}
        return BitConverter.ToSingle(cmd_buf, offset);
    }


    public byte[] write_float(byte[] cmd_buf, int offset, float value)
    {
        byte[] result = BitConverter.GetBytes(value);
        //if (BitConverter.IsLittleEndian)
        //{
        //    //Array.Reverse(result);
        //}
        Buffer.BlockCopy(result, 0, cmd_buf, offset, result.Length);
        return cmd_buf;
    }

    public string read_str(byte[] cmd_buf, int offset,int byte_len)
    {
        return extend.read_utf8(cmd_buf,offset,byte_len);
    }

    public void write_str(byte[] cmd_buf, int offset, string value)
    {
        extend.write_utf8(cmd_buf, offset, value);
    }

    public int write_cmd_header_inbuf(byte[] cmd_buf, int stype,int ctype)
    {
        this.write_int16(cmd_buf, 0, (short)stype);
        this.write_int16(cmd_buf, 2, (short)ctype);
        this.write_int32(cmd_buf, 4, 0);
        return this.header_size;
    }

    public void write_prototype_inbuf(byte[] cmd_buf,proto_type proto_Type)
    {
        this.write_int16(cmd_buf,8,(short)proto_Type);
    }

    public int write_str_inbuf(byte[] cmd_buf, int offset,string str, int byte_len)
    {
        write_int16(cmd_buf, offset, (short)byte_len);
        offset += 2;
        write_str(cmd_buf,offset,str);
        offset += byte_len;
        return offset;
    }

    public ArrayList read_str_inbuf(byte[] cmd_buf, int offset)
    {
        int byte_len = read_int16(cmd_buf,offset);
        offset += 2;
        string str = read_str(cmd_buf,offset,byte_len);
        offset += byte_len;
        ArrayList arrayList = new ArrayList();
        arrayList.Add(str);
        arrayList.Add(offset);
        return arrayList;
    }

    public ArrayList decode_empty_cmd(byte[] cmd_buf)
    {
        ArrayList cmd = new ArrayList();
        cmd.Add(read_int16(cmd_buf, 0));
        cmd.Add(read_int16(cmd_buf, 2));
        cmd.Add(null);
        return cmd;

    }

    public byte[] encode_empty_cmd(int stype, int ctype,object body)
    {
        byte[] cmd_buf = this.alloc_Buffer(this.header_size);
        this.write_cmd_header_inbuf(cmd_buf, stype, ctype);
        return cmd_buf;
    }

    public byte[] encode_status_cmd(int stype, int ctype, int status)
    {
        byte[] cmd_buf = this.alloc_Buffer(this.header_size);
        this.write_cmd_header_inbuf(cmd_buf, stype, ctype);
        this.write_int16(cmd_buf,this.header_size,(short)status);
        return cmd_buf;
    }

    public ArrayList decode_status_cmd(byte[] cmd_buf)
    {
        ArrayList cmd = new ArrayList();
        cmd.Add(read_int16(cmd_buf, 0));
        cmd.Add(read_int16(cmd_buf, 2));
        cmd.Add(read_int16(cmd_buf, this.header_size));
        return cmd;
    }

    public byte[] encode_int32_cmd(int stype, int ctype,int value)
    {
        byte[] cmd_buf = alloc_Buffer(this.header_size + 4);
        this.write_cmd_header_inbuf(cmd_buf, stype, ctype);
        this.write_int32(cmd_buf, header_size, value);
        return cmd_buf;
    }

    public ArrayList decode_int32_cmd(byte[] cmd_buf)
    {
        ArrayList cmd = new ArrayList();
        cmd.Add(read_int16(cmd_buf, 0));
        cmd.Add(read_int16(cmd_buf, 2));
        cmd.Add(read_int32(cmd_buf, this.header_size));
        return cmd;
    }

    public byte[] encode_str_cmd(int stype, int ctype, string value)
    {
        int len = extend.utf8_byte_len(value);
        int total_len = header_size + 2 + len;
        byte[] cmd_buf = alloc_Buffer(total_len);
        int offset = this.write_cmd_header_inbuf(cmd_buf, stype, ctype);
        this.write_str_inbuf(cmd_buf, offset, value, len);
        return cmd_buf;
    }

    public ArrayList decode_str_cmd(byte[] cmd_buf)
    {
        ArrayList cmd = new ArrayList();
        cmd.Add(read_int16(cmd_buf, 0));
        cmd.Add(read_int16(cmd_buf, 2));
        cmd.Add(read_str_inbuf(cmd_buf, this.header_size)[0]);
        return cmd;
    }
}

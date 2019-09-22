using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public static class extend 
{
    public static void write_utf8( byte[] src, int offset,string str)
    {
        byte[] data = Encoding.UTF8.GetBytes(str);
        Buffer.BlockCopy(data, 0, src, offset, data.Length);
    }

    public static string read_utf8(byte[] src,int offset,int byte_length)
    {
        string str = "";
        str = Encoding.UTF8.GetString(src, offset, byte_length);
        return str;
    }

    public static int utf8_byte_len(string src)
    {
        int len = 0;
        len = Encoding.UTF8.GetByteCount(src);
        return len;
    }
}

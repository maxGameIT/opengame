using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;
using System;

public static class utils 
{
  public static string random_string(int len)
    {
        byte[] b = new byte[4];
        new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
        System.Random r = new System.Random(System.BitConverter.ToInt32(b, 0));

        string str = null;
        str += "0123456789";
        str += "abcdefghijklmnopqrstuvwxyz";
        str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        string s = null;

        for (int i = 0; i < len; i++)
        {
            s += str.Substring(r.Next(0, str.Length - 1), 1);
        }
        return s;
    }


    public static string random_int_str(int len)
    {
        byte[] b = new byte[4];
        new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
        System.Random r = new System.Random(System.BitConverter.ToInt32(b, 0));

        string str = null;
        str += "0123456789";
        string s = null;

        for (int i = 0; i < len; i++)
        {
            s += str.Substring(r.Next(0, str.Length - 1), 1);
        }
        return s;
    }

    public static int random_int(int start,int end)
    {
        return UnityEngine.Random.Range(start, end);
    }


    public static string GetMD5(string data)
    {
        string str = "";
        byte[] body = Encoding.UTF8.GetBytes(data);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] result = md5.ComputeHash(body);
        str = BitConverter.ToString(result).Replace("-", "").ToLower();
        return str;

    }


}

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

class httpMgr
{
    static httpMgr g_instance;
    public static httpMgr Instance()
    {
        if (g_instance == null)
        {
            g_instance = new httpMgr();
        }
        return g_instance;
    }

    public string AddKey(string key ,string value,bool isfirst = false)
    {
        string str = "";
        if (isfirst)
        {
            str += "?" + key + "=" + value;
        }
        else
        {
            str += "&" + key + "=" + value;
        }
        return str;
    }


    public IEnumerator get(string url,string path,Action<object,object> callback,  string vs = "")
    {
        UnityWebRequest www;
        string requestURL  = url + path;
        if (!string.IsNullOrEmpty(vs))
        {
            requestURL += vs;
        }
        www = UnityWebRequest.Get(requestURL);
        //www.SetRequestHeader("Accept-Encoding", "gzip,deflate");
        www.timeout = 5000;
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            try
            {
                if (www.responseCode >= 200 && www.responseCode < 300)
                {
                    string responseText = www.downloadHandler.text;
                    if (callback != null)
                    {
                        callback(null, responseText);
                    }
                }
               
            }
            catch 
            {
                if (callback != null)
                {
                    callback(www.error, null);
                }
            }
        }
        yield return www.SendWebRequest();
    }

    public IEnumerator post(string url, string path,string body, Action<object, object> callback, string vs = "")
    {
        UnityWebRequest www;
        string requestURL = url + path;
        if (!string.IsNullOrEmpty(vs))
        {
            requestURL += vs;
        }
        www = UnityWebRequest.Post(requestURL,body);
        if (!string.IsNullOrEmpty(body))
        {
            www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            www.SetRequestHeader("Content-Length", body.Length.ToString());
        }
        www.timeout = 5000;
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            try
            {
                if(www.responseCode >= 200 && www.responseCode < 300)
                {
                    string responseText = www.downloadHandler.text;
                    if (callback != null)
                    {
                        callback(null, responseText);
                    }
                }
            }
            catch
            {
                if (callback != null)
                {
                    callback(www.error, null);
                }
            }
        }
        yield return www.SendWebRequest();
    }

    public IEnumerator download(string url, string path, Action<object, object> callback, string vs = "")
    {
        UnityWebRequest www;
        string requestURL = url + path;
        if (!string.IsNullOrEmpty(vs))
        {
            requestURL += vs;
        }
        www = UnityWebRequest.Get(requestURL);
        //www.SetRequestHeader("Accept-Encoding", "gzip,deflate");
        www.timeout = 5000;
        
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            try
            {
                if (www.responseCode >= 200  && www.responseCode < 300)
                {
                    byte[] responseText = www.downloadHandler.data;
                    if (callback != null)
                    {
                        callback(null, responseText);
                    }
                }
            }
            catch
            {
                if (callback != null)
                {
                    callback(www.error, null);
                }
            }
        }
        yield return www.SendWebRequest();
    }
}
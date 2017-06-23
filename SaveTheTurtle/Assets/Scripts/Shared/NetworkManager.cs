using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json;
using System.Text;
using System;
using Newtonsoft.Json;
using System.IO;

public class NetworkManager : MonoBehaviour
{

    public static string URL = "http://127.0.0.1:5000/json";

    private Action<int> mCallback;

    public void SendData(float[] data, Action<int> callback)
    {
        mCallback = callback;
        Dictionary<string, string> postHeader = new Dictionary<string, string>();
        postHeader.Add("Content-Type", "application/json");

        string jsonData = JsonConvert.SerializeObject(data);
        Debug.Log(jsonData);

        SaveFile(jsonData);

        byte[] byteData = Encoding.ASCII.GetBytes(jsonData);

        WWW www = new WWW(URL, byteData, postHeader);

        StartCoroutine(WaitForRequest(www));
    }

    private void SaveFile(String json)
    {
        string fileName = Guid.NewGuid().ToString() + ".json";

        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " already exists.");
            return;
        }

        var sr = File.CreateText(fileName);
        sr.WriteLine(json);
        sr.Close();
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.data);

            if (mCallback != null)
            {
                mCallback.Invoke(JsonConvert.DeserializeObject<int>(www.data));
            }
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}

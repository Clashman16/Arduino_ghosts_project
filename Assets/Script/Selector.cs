using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Selector : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM3", 19200); //todo check if arduino is connected at COM7, in arduino editor->tools + same refresh time as me + if pb check .Net 4x in unity
    public string receivedDatas;
    public bool devMode;

    private void Start()
    {
        if (!devMode)
        {
            data_stream.Open();
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (devMode)
        {
            transform.SetPositionAndRotation(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), transform.rotation);
            return;
        }
        receivedDatas = data_stream.ReadLine();
        print("Received Datas: " + receivedDatas);
        string[] datas = receivedDatas.Split(',');
        for (int i = 0; i < datas.Length; ++i) print(datas[i]);
        transform.SetPositionAndRotation(new Vector3(float.Parse(datas[0]), float.Parse(datas[1]), 0), transform.rotation);
        //print("x = " + Input.mousePosition.x);
        //print("y = " + Input.mousePosition.y);
    }
}

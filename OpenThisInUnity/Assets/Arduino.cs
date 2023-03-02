using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduino : MonoBehaviour
{

    public static string portName = "COM3"; //change this to arduino port
    public static int portSpeed = 9600;
    private SerialPort sp = new SerialPort(portName, portSpeed);
    private bool state;
    private string byteValue;

    void Awake()
    {
        OpenConnection();
        
    }

    void Update()
    {
       
        if (sp.IsOpen)
        {
            string value = ReadSerialPort();
         
         if (value != null)
         {
             //Debug.Log(value);
             
             if (value == "on")
             {
                //do something

             }
             else if (value == "off")
             {
                 //do something
             }
         }

        }
        
    }
    
    
    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                Debug.Log("Closing port, because it's already open");
            }
            else
            {
                sp.Open();
                sp.ReadTimeout = 1;
                Debug.Log("port open at" + portName + portSpeed);
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                Debug.Log("port is already open");
            }
            else
            {
                Debug.Log("port == null");
            }
        }
    }



    public string ReadSerialPort(int timeout = 10)
    {
        string readByte;
        sp.ReadTimeout = timeout;
        
        //we will try to read values from our serial port
        try
        {
            readByte = sp.ReadLine();
            return readByte;
        }
        catch(TimeoutException)
        {
            return null;
        }
    }
    
    public void WriteSerialPort(string text)
    {
       sp.Write(text);
       Debug.Log(text);
    }

}
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Text;
using UnityStandardAssets.Vehicles.Car;
using System.Threading;
using System.IO;

public class Server_Controller : MonoBehaviour {

    const float TIME_BREAK = 100;

    public static int port = 9999;
    public static IPAddress ipAddress;
    int maxConnections = 2;
    Socket listener;
    SpeedAndAngle sAA, presAA;
    float break_time = 0;


    public const int BufferSize = 1024;
    public byte[] buffer = new byte[BufferSize];

    public List<Socket> listClient = new List<Socket>();

    // Use this for initialization
    void Start () {
        print("Start Server_Controller call");
        sAA = new SpeedAndAngle();
        sAA.speed = 0;
        sAA.angle = 0;
        sAA.request = "NONE";

        presAA = new SpeedAndAngle();
        presAA.speed = 1;
        presAA.angle = sAA.angle;

        string json = JsonUtility.ToJson(sAA);
        print(json);

        Application.runInBackground = true;
        StartListening();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3(carX, carY, carZ);
        //CarUserControl.m_Car.Move(sAA.angle, 0, 0, 1);
        if ((CarUserControl.useOutSide == 1) && (sAA.angle != 6969))
        {
            //if (presAA.speed == sAA.speed)
            //    CarUserControl.m_Car.Move(sAA.angle, sAA.speed, sAA.speed, 0);
            //else
            //    CarUserControl.m_Car.Move(sAA.angle, sAA.speed, 0, 0);

            //presAA = sAA;
            //Thread.Sleep(2000);
            if (break_time > 0)
            {
                CarUserControl.m_Car.Move(sAA.angle, 0, 1, 0);
                break_time--;
                //print(break_time);
                if (break_time <= 0)
                {
                    presAA.speed = 1;
                    presAA.angle = sAA.angle;
                    print("copied " + sAA.speed);
                }
            }
            else 
            {
                print(presAA.speed);
                if (presAA.speed > 0) // Still move
                {
                    CarUserControl.m_Car.Move(sAA.angle, sAA.speed, 0f, 0f);
                    presAA.speed--;
                    print("do once");
                }
                else // Add break time
                {
                    print("Break Time!");
                    break_time = (TIME_BREAK - sAA.speed) / 5;
                }
            }
        }
        
    }

    void StartListening()
    {
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        ipAddress = ipHostInfo.AddressList[0];

        // Get localhost
        foreach (IPAddress ip in ipHostInfo.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                ipAddress = ip;
            }
        }
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

        listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(100);

            print("IP/PORT: " + ipAddress.ToString() + "/" + port.ToString());
            print("Waiting for a connection...");

            listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
        }
        catch (Exception ex)
        {
            print(ex.ToString());
        }
    }

    public void AcceptCallback(IAsyncResult ar)
    {
        Socket handler = listener.EndAccept(ar);
        listClient.Add(handler);
        print(handler.RemoteEndPoint.ToString() + " connected!");

        handler.BeginReceive(buffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), handler);

        print("Waiting for a connection...");
        listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
    }

    private void ReadCallback(IAsyncResult ar)
    {
        Socket handler = (Socket)ar.AsyncState;

        if (handler.Connected)
        {
            int bytesRead;
            try
            {
                bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        string temp = buffer[i].ToString();
                        //Console.Write(temp);
                    }
                    //Console.WriteLine();
                    string text = Encoding.ASCII.GetString(buffer);

                    //Parse Json
                    sAA = JsonUtility.FromJson<SpeedAndAngle>(text);

                    /// Calculate Angle ratio
                    sAA.angle = 1 / (45 / sAA.angle);

                    //Control speed and Angle
                    //CarUserControl.useOutSide = 1;

                    print(sAA.speed.ToString() + " " + sAA.angle.ToString() + CarUserControl.useOutSide + sAA.request);
                    
                    Array.Clear(buffer, 0, buffer.Length);

                    //Request speed
                    if (sAA.request == "SPEED")
                    {
                        print("GET SPEED");
                        byte[] byteData = Encoding.ASCII.GetBytes(((int)CarUserControl.speed).ToString());
                        handler.BeginSend(byteData, 0, byteData.Length, 0,
                                new AsyncCallback(SendCallback), handler);
                    }

                    //Request Angle
                    else if (sAA.request == "ANGLE")
                    {
                        byte[] byteData = Encoding.ASCII.GetBytes(((int)CarUserControl.angle).ToString());
                        handler.BeginSend(byteData, 0, byteData.Length, 0,
                                new AsyncCallback(SendCallback), handler);
                    }

                }
                else   // Disconnected
                {
                    foreach (Socket sc in listClient)
                    {
                        if (sc.RemoteEndPoint.ToString().Equals(handler.RemoteEndPoint.ToString()))
                        {
                            listClient.Remove(sc);
                            print(handler.RemoteEndPoint.ToString() + " disconnected!");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        handler.BeginReceive(buffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), handler);
    }

    private void SendCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket handler = (Socket)ar.AsyncState;

            // Complete sending the data to the remote device.  
            int bytesSent = handler.EndSend(ar);
            print("Sent {0} bytes to client." + bytesSent);

            //handler.Shutdown(SocketShutdown.Both);
            //handler.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private void Send_File()
    {
        string fileName = Application.dataPath + "/Snapshots/fx_UIT_Car.png";

    }
}

public class SpeedAndAngle
{
    public float speed;
    public float angle;
    public string request;
}

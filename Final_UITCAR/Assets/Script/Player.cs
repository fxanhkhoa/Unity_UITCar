using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Camera snapCam;
    Texture2D snapshot;
    Rect snapRect;
    RenderTexture rt;
    byte[] bytes;
    string fileName;

    int resWidth = 256;
    int resHeight = 256;

    int port = 9999;
    string ip = "localhost";
    NetworkClient client;

    // For car controller
    private CarUserControl m_Car;
    private CarController mCarController;

    public GameObject datap;
    public GameObject currentMode;
    float i = 0;

    private void Awake()
    {
        Debug.Log("Awake call");
        mCarController = GetComponent<CarController>();
        fileName = Application.dataPath + "/Snapshots/fx_UIT_Car.png";
        print("Init done");
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Start call");
        //Time.captureFramerate = 30;
        snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        snapRect = new Rect(0, 0, resWidth, resHeight);
        rt = RenderTexture.active;
        RenderTexture.active = snapCam.targetTexture;
        try
        {
            snapCam = GameObject.Find("Camera").GetComponent<Camera>();
            resWidth = snapCam.pixelWidth;
            resHeight = snapCam.pixelHeight;
            //snapCam = Camera.main;
            if (snapCam.targetTexture == null)
            {
                snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
            }
            else
            {
                resWidth = snapCam.targetTexture.width;
                resHeight = snapCam.targetTexture.height;
            }
            print("initialized!");
        }
        catch (Exception ex)
        {
            print(ex);
        }  
    }

    // Update is called once per frame
    void Update () {
        datap.GetComponent<Text>().text = Server_Controller.ipAddress.ToString() + "/" + Server_Controller.port.ToString();
        if (CarUserControl.useOutSide == 1)
        {
            currentMode.GetComponent<Text>().text = "Mode Auto Pilot";
        }
        else
        {
            currentMode.GetComponent<Text>().text = "Mode Manual";
        }
        
        saveFrame();
        if ((Input.GetKeyDown(KeyCode.Alpha0)) || (Input.GetKeyDown(KeyCode.M)))
        {
            print("clicked 0");
            if (CarUserControl.useOutSide == 1)
            {
                CarUserControl.useOutSide = 0;
            }
            else
            {
                CarUserControl.useOutSide = 1;
            }
            //i += 0.01f;
            //CarUserControl.m_Car.Move(0f, 10f, 0f, 0f);
            print(CarUserControl.useOutSide);
        }
        //if (Input.GetKeyUp(KeyCode.KeypadPlus))
        //{
        //    print("key up keypadplus");
        //    CarUserControl.useOutSide = 0;
        //}
        if (Input.GetKeyDown(KeyCode.F8))
        {
            var config = new ConnectionConfig();

            // Config the Channels we will use
            config.AddChannel(QosType.ReliableFragmented);
            config.AddChannel(QosType.UnreliableFragmented);

            // Create the client ant attach the configuration
            client = new NetworkClient();
            client.Configure(config, 1);

            // Register the handlers for the different network messages
            //RegisterHandlers();

            // Connect to the server
            client.Connect(ip, port);
        }
    }
    private void OnPostRender()
    {
        
    }

    private void saveFrame()
    {
        print("Rendering");
        snapCam.Render();
        RenderTexture.active = snapCam.targetTexture;
        //tex = RenderTexture.active;
        //snapshot = toTexture2D(tex);
        UnityEngine.Object.Destroy(snapshot);
        snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        snapRect = new Rect(0, 0, resWidth, resHeight);
        snapshot.ReadPixels(snapRect, 0, 0);
        snapshot.Apply();
        bytes = snapshot.EncodeToPNG();
        //string fileName = SnapshotName();
        System.IO.File.WriteAllBytes(fileName, bytes);
        print("Snapshot taken!");
        GC.Collect();
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        RenderTexture.active = rTex;
        Texture2D snap = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        snap.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        snap.Apply();
        return snap;
    }

    string SnapshotName()
    {
        return string.Format("{0}/Snapshots/snap_{1}x{2}_{3}.png",
            Application.dataPath,
            resWidth,
            resHeight,
            System.DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss"));
    }
}

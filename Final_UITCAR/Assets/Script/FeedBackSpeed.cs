using UnityEngine;
using System.Collections;
using System.IO;
using UnityStandardAssets.Vehicles.Car;
using System;

public class FeedBackSpeed : MonoBehaviour {

    FileStream fs;
    StreamWriter sw;
    float CurrentSpeed = 0;
    float CurrentSteerAngle = 0;
    // Use this for initialization
    void Start () {
        if (!File.Exists(@"feedBack.txt"))
        {
            fs = new FileStream("feedBack.txt", FileMode.CreateNew);
        }
        sw = new StreamWriter(@"feedBack.txt", false);
        //sw.WriteLine((current + 1).ToString() + "/" + CheckPointManager.TotalCheckPoint.ToString());
        //sw.WriteLine(CheckPointManager.MinuteBestAtCheckPoint[current] + ":"
        //                                + CheckPointManager.SecondBestAtCheckPoint[current]
        //                                + ":" + CheckPointManager.MilliBestAtCheckPoint[current]);
        //sw.Close();
    }

    // Update is called once per frame
    void Update () {
        try
        {
            //sw = new StreamWriter(@"feedBack.txt", false);
            //CurrentSpeed = CarUserControl.m_Car.CurrentSpeed;
            //CurrentSteerAngle = CarUserControl.m_Car.CurrentSteerAngle;
            //print("Current:" + CurrentSpeed.ToString() + CurrentSteerAngle.ToString());
            //sw.WriteLine(CurrentSpeed.ToString() + "|" + CurrentSteerAngle.ToString());
            //sw.Close();
            
        }
        catch (Exception e)
        {
            print(e);
        }
	}
}

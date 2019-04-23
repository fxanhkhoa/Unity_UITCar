using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CheckPointManager : MonoBehaviour {

    public static int TotalCheckPoint = 10;
    public static int TotalCurrenCheckPoint = 0;
    public static int BestTotalCheckPoint = 0;

    public static int MinuteBestCount = 99;
    public static int SecondBestCount = 99;
    public static float MilliBestCount = 99;

    public static int[] MinuteBestAtCheckPoint = new int[TotalCheckPoint];
    public static int[] SecondBestAtCheckPoint = new int[TotalCheckPoint];
    public static float[] MilliBestAtCheckPoint = new float[TotalCheckPoint];

    public GameObject CheckPointBox;
    public GameObject MinuteBest;
    public GameObject SecondBest;
    public GameObject MiliBest;

    public GameObject LapBestComplete;

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < TotalCheckPoint; i++)
        {
            MinuteBestAtCheckPoint[i] = 99;
            SecondBestAtCheckPoint[i] = 99;
            MilliBestAtCheckPoint[i] = 99;
        }
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            //print("worked?");
            int currentBest = checkCurrentBest();
            //print("Worked again");
            ////////// Show Best Lap Checkpoint/////////////
            ///

            LapBestComplete.GetComponent<Text>().text = BestTotalCheckPoint + "/" + TotalCheckPoint;
            print(TotalCheckPoint);

            ////////// Show Current Lap Checkpoint/////////////
            ///
            CheckPointBox.GetComponent<Text>().text = TotalCurrenCheckPoint + "/" + TotalCheckPoint;

            if (MinuteBestAtCheckPoint[currentBest] <= 9)
            {
                MinuteBest.GetComponent<Text>().text = "0" + MinuteBestAtCheckPoint[currentBest] + ".";
            }
            else
            {
                MinuteBest.GetComponent<Text>().text = "" + MinuteBestAtCheckPoint[currentBest] + ".";
            }
            
            if (SecondBestAtCheckPoint[currentBest] <= 9)
            {
                SecondBest.GetComponent<Text>().text = "0" + SecondBestAtCheckPoint[currentBest] + ".";
            }
            else
            {
                SecondBest.GetComponent<Text>().text = "" + SecondBestAtCheckPoint[currentBest] + ".";
            }
            
            MiliBest.GetComponent<Text>().text = MilliBestAtCheckPoint[currentBest].ToString("F0");
        }
        catch (Exception ex)
        {
            
        }
    }

    private int checkCurrentBest()
    {
        //print("Here");
        for (int i = TotalCheckPoint - 1; i > 0; i--)
        {
            //print(i);
            if (SecondBestAtCheckPoint[i] < 99)
            {
                //print(i.ToString() + SecondBestAtCheckPoint[i]);
                return i;
            }
        }
        return 0;
    }
}

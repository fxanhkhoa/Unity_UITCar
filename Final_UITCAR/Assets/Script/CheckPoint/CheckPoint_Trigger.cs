using UnityEngine;
using System.Collections;

public class CheckPoint_Trigger : MonoBehaviour {

    public GameObject CheckPoint;

    private void Start()
    {
        //StartTrig.SetActive(false);
        //CheckPoint1Trig.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Triggerd..");
        CheckPointManager.TotalCurrenCheckPoint ++;
        if (CheckPointManager.BestTotalCheckPoint < CheckPointManager.TotalCurrenCheckPoint)
        {
            CheckPointManager.BestTotalCheckPoint = CheckPointManager.TotalCurrenCheckPoint;
        }
        CheckPoint.SetActive(false);
        SaveBestCheckPointTime();
    }
   
    private void SaveBestCheckPointTime()
    {
        //print("Num = " + CheckPointManager.TotalCurrenCheckPoint);
        if (CheckPointManager.MinuteBestAtCheckPoint[CheckPointManager.TotalCurrenCheckPoint - 1] > LaptimeManager.MinuteCount)
        {
            CheckPointManager.MinuteBestAtCheckPoint[CheckPointManager.TotalCurrenCheckPoint - 1] = LaptimeManager.MinuteCount;
            CheckPointManager.SecondBestAtCheckPoint[CheckPointManager.TotalCurrenCheckPoint - 1] = LaptimeManager.SecondCount;
            CheckPointManager.MilliBestAtCheckPoint[CheckPointManager.TotalCurrenCheckPoint - 1] = LaptimeManager.MilliCount;
        }
        else
        {
            if (CheckPointManager.SecondBestAtCheckPoint[CheckPointManager.TotalCurrenCheckPoint - 1] > LaptimeManager.SecondCount)
            {
                //print("second count: " + LaptimeManager.SecondCount);
                CheckPointManager.SecondBestAtCheckPoint[CheckPointManager.TotalCurrenCheckPoint - 1] = LaptimeManager.SecondCount;
                CheckPointManager.MilliBestAtCheckPoint[CheckPointManager.TotalCurrenCheckPoint - 1] = LaptimeManager.MilliCount;
            }
            else
            {
                if (CheckPointManager.MilliBestAtCheckPoint[CheckPointManager.TotalCurrenCheckPoint - 1] > LaptimeManager.MilliCount)
                {
                    CheckPointManager.MilliBestAtCheckPoint[CheckPointManager.TotalCurrenCheckPoint - 1] = LaptimeManager.MilliCount;
                }
            }
        }
        
    }
}

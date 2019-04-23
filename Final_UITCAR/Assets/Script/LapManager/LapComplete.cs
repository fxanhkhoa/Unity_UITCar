using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {

    public GameObject LapCompleteTrig;
    public GameObject StartTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MiliDisplay;

    public GameObject LapTimeBox;

    private void OnTriggerEnter(Collider other)
    {
        if (LaptimeManager.SecondCount <= 9)
        {
            SecondDisplay.GetComponent<Text>().text = "0" + LaptimeManager.SecondCount + ".";
        }
        else
        {
            SecondDisplay.GetComponent<Text>().text = "" + LaptimeManager.SecondCount + ".";
        }

        if (LaptimeManager.MinuteCount <= 9)
        {
            MinuteDisplay.GetComponent<Text>().text = "0" + LaptimeManager.MinuteCount + ".";
        }
        else
        {
            MinuteDisplay.GetComponent<Text>().text = "" + LaptimeManager.MinuteCount + ".";
        }

        //Save the best time
        if (CheckPointManager.MinuteBestCount > LaptimeManager.MinuteCount)
        {
            CheckPointManager.MinuteBestCount = LaptimeManager.MinuteCount;
            CheckPointManager.SecondBestCount = LaptimeManager.SecondCount;
            CheckPointManager.MilliBestCount = LaptimeManager.MilliCount;
        }
        else
        {
            if (CheckPointManager.SecondBestCount > LaptimeManager.SecondCount)
            {
                CheckPointManager.MinuteBestCount = LaptimeManager.MinuteCount;
                CheckPointManager.SecondBestCount = LaptimeManager.SecondCount;
                CheckPointManager.MilliBestCount = LaptimeManager.MilliCount;
            }
            else
            {
                if (CheckPointManager.MilliBestCount > LaptimeManager.MilliCount)
                {
                    CheckPointManager.MinuteBestCount = LaptimeManager.MinuteCount;
                    CheckPointManager.SecondBestCount = LaptimeManager.SecondCount;
                    CheckPointManager.MilliBestCount = LaptimeManager.MilliCount;
                }
            }
        }

        /////////////// Display Best /////////////////
        

        MiliDisplay.GetComponent<Text>().text = "" + LaptimeManager.MilliCount;

        LaptimeManager.MinuteCount = 0;
        LaptimeManager.SecondCount = 0;
        LaptimeManager.MilliCount = 0;

        StartTrig.SetActive(true);
        //LapCompleteTrig.SetActive(true);
    }
}

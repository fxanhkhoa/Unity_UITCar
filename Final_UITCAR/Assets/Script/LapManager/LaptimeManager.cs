using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LaptimeManager : MonoBehaviour {

    public static int MinuteCount = 0;
    public static int SecondCount = 0;
    public static float MilliCount = 0;

    public static int MinuteLeft = 7;
    public static int SecondLeft = 0;

    public static string MilliDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

    public GameObject MinuteLeftBox;
    public GameObject SecondLeftBox;

    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        MilliCount += Time.deltaTime * 10;
        MilliDisplay = MilliCount.ToString("F0");
        MilliBox.GetComponent<Text>().text = "" + MilliDisplay;

        if (MilliCount >= 10)
        {
            MilliCount = 0;
            SecondCount += 1;
            SecondLeft -= 1;
        }

        if (SecondCount <= 9)
        {
            SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
        }
        else
        {
            SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
        }

        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }

        if (MinuteCount <= 9)
        {
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
        }
        else
        {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
        }

        ///////////// Time Left /////////////
        ///

        if (SecondLeft < 0)
        {
            SecondLeft = 59;
            MinuteLeft -= 1;
        }

        if (SecondLeft <= 9)
        {
            SecondLeftBox.GetComponent<Text>().text = "0" + SecondLeft+ ".";
        }
        else
        {
            SecondLeftBox.GetComponent<Text>().text = "" + SecondLeft + ".";
        }

        if (MinuteCount <= 9)
        {
            MinuteLeftBox.GetComponent<Text>().text = "0" + MinuteLeft + ":";
        }
        else
        {
            MinuteLeftBox.GetComponent<Text>().text = "" + MinuteLeft + ":";
        }

        // out of time ==> jump to next scene
        if ((MinuteLeft <= 0) && (SecondLeft <= 0))
        {
            if (!File.Exists(@"Result.txt"))
            {
                FileStream fs = new FileStream("Result.txt", FileMode.CreateNew);
            }

            int current = checkCurrentBest();

            StreamWriter sw = new StreamWriter(@"Result.txt", false);
            sw.WriteLine((current + 1).ToString() + "/" + CheckPointManager.TotalCheckPoint.ToString());
            sw.WriteLine(CheckPointManager.MinuteBestAtCheckPoint[current] + ":"
                                            + CheckPointManager.SecondBestAtCheckPoint[current]
                                            + ":" + CheckPointManager.MilliBestAtCheckPoint[current]);
            sw.Close();
            print("Done and now Jump");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private int checkCurrentBest()
    {
        //print("Here");
        for (int i = CheckPointManager.TotalCheckPoint - 1; i > 0; i--)
        {
            //print(i);
            if (CheckPointManager.SecondBestAtCheckPoint[i] < 99)
            {
                //print(i.ToString() + CheckPointManager.SecondBestAtCheckPoint[i]);
                return i;
            }
        }
        return 0;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class EndGame : MonoBehaviour {

    public GameObject BestLap;
    public GameObject BestTime;
    int currentI;

	// Use this for initialization
	void Start () {
        StreamReader sr = new StreamReader(@"Result.txt");
        BestLap.GetComponent<Text>().text = sr.ReadToEnd();
        sr.Close();
    }
	
	// Update is called once per frame
	void Update () {
        //currentI = checkCurrentBest();
        //BestLap.GetComponent<Text>().text = (currentI + 1).ToString() + "/" + CheckPointManager.TotalCheckPoint;
        //BestTime.GetComponent<Text>().text = CheckPointManager.MinuteBestAtCheckPoint[currentI] + ":" 
        //                                    + CheckPointManager.SecondBestAtCheckPoint[currentI]
        //                                    + ":" + CheckPointManager.MilliBestAtCheckPoint[currentI];
	}

    private int checkCurrentBest()
    {
        //print("Here");
        for (int i = CheckPointManager.TotalCheckPoint - 1; i > 0; i--)
        {
            print(i);
            if (CheckPointManager.SecondBestAtCheckPoint[i] < 99)
            {
                print(i.ToString() + CheckPointManager.SecondBestAtCheckPoint[i]);
                return i;
            }
        }
        return 0;
    }
}

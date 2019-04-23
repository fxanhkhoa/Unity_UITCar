using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using System;

public class OutLine : MonoBehaviour {

    private const int NUM_DELAY = 50;
    int preUseOutSide = 0;
    public GameObject mCar;

    public GameObject CheckPoint1;
    public GameObject CheckPoint2;
    public GameObject CheckPoint3;
    public GameObject CheckPoint4;
    public GameObject CheckPoint5;
    public GameObject CheckPoint6;
    public GameObject CheckPoint7;
    public GameObject CheckPoint8;
    public GameObject CheckPoint9;
    public GameObject CheckPoint10;

    int isbreak = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetCar();
        }

        if (isbreak > 0)
        {
            CarUserControl.m_Car.Move(0f, -100f, 100f, 100f);
            //CarUserControl.m_Car.StopAllCoroutines();
            // For Round 2
            //mCar.transform.position = new Vector3(374.09f, 0f, 8.47f);
            //mCar.transform.eulerAngles = new Vector3(0f, -4.79f, 0f);
            // For Round 1
            //mCar.transform.position = new Vector3(35f, 0.010915f, 14.67f);
            //mCar.transform.eulerAngles = new Vector3(0f, -15.96f, 0f);
            isbreak--;
            if (isbreak == 0)
            {
                CarUserControl.m_Car.Move(0f, -5f, 0f, -1f);
                CarUserControl.m_Car.Move(0f, 5f, -1f, 0f);
                //CarUserControl.m_Car.Move(0f, 5f, 0f, 0f);
                //mCar.transform.position = new Vector3(374.09f, 0f, 8.47f);
                //mCar.transform.eulerAngles = new Vector3(0f, -4.79f, 0f);
                // For Round 1
                mCar.transform.position = new Vector3(71.89f, 0f, 11.86717f);
                mCar.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                CarUserControl.resetting = 0;
                print("controlled");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        resetCar();
    }

    private void resetCar()
    {
        CarUserControl.resetting = 1;
        try
        {
            CheckPoint1.SetActive(true);
            CheckPoint2.SetActive(true);
            CheckPoint3.SetActive(true);
            CheckPoint4.SetActive(true);
            CheckPoint5.SetActive(true);
            CheckPoint6.SetActive(true);
            CheckPoint7.SetActive(true);
            CheckPoint8.SetActive(true);
            CheckPoint9.SetActive(true);
        }
        catch (Exception ex)
        {

        }

        CheckPointManager.TotalCurrenCheckPoint = 0;
        LaptimeManager.MinuteCount = 0;
        LaptimeManager.SecondCount = 0;
        LaptimeManager.MilliCount = 0;
        // For Round 2
        mCar.transform.position = new Vector3(71.89f, 0f, 11.86717f);
        mCar.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        // For Round 1
        //mCar.transform.position = new Vector3(35f, 0.010915f, 14.67f);
        //mCar.transform.eulerAngles = new Vector3(0f, -15.96f, 0f);
        isbreak = NUM_DELAY;
        //FinishTrig.SetActive(true);
        CheckPoint10.SetActive(true);
    }
}

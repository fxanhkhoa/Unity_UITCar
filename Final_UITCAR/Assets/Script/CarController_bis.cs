using UnityEngine;
using System.Collections;

public class CarController_bis : MonoBehaviour {

    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelBL;
    public WheelCollider WheelBR;

    public GameObject theCar;

    public GameObject FL;
    public GameObject FR;
    public GameObject BL;
    public GameObject BR;

    public float carX, carY, carZ;
	public float carRotateX, carRotateY, carRotateZ;
    public float timeSpan = 0.3f;
    private bool click_and_hold;
    private float time;

    public float topSpeed = 250f;
    public float maxTorque = 200f;
    public float maxSteerAngle = 45f;
    public float currentSpeed;
    public float maxBrakeTorque = 2200;

    private float Forward, Turn, Brake;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        carX = (float)15.45;
        carY = (float)-0.0006765375;
        carZ = (float)138.52;

    }



    // Update is called once per frame
    void Update () {
       
    }

    void checkKeyUp()
    {
        if (click_and_hold)
        {
            carX += (float)0.1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            click_and_hold = true;
            print("press down");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            click_and_hold = false;
            print("press up");
        }
    }
}

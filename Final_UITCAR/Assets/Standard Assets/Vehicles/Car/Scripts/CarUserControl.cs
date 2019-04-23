using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        public static CarController m_Car; // the car controller we want to use
        public static int useOutSide = 0;
        public static int resetting = 0;
        public static float speed = 0;
        public static float angle = 0;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            useOutSide = 0;
        }


        private void FixedUpdate()
        {
            angle = m_Car.CurrentSteerAngle;
            speed = m_Car.CurrentSpeed;
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            if (useOutSide == 0)
            {
                if (resetting == 0)
                    m_Car.Move(h, v, v, handbrake);
            }
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}

using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public float angle;
        public bool usingWheel;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        public void Move(float h, float v, float handbrake)
        {
			m_Car.Move(h, v, v, handbrake);

		}

        private void FixedUpdate()
        {

            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");

            if (usingWheel)
            {
                m_Car.Move(angle, v, v, handbrake);
            }
            else
            {
                m_Car.Move(h, v, v, handbrake);
            }
#else
            if(usingWheel)
            {
                m_Car.Move(angle, v, v, handbrake);
            } else
            {
            m_Car.Move(h, v, v, 0f);
            }
#endif
        }
    }
}
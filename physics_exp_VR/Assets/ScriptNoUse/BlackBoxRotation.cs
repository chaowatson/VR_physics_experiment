using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoxRotation : MonoBehaviour
{
    public Rigidbody blackbox;
    public GameObject mass;
    public static float speed = 0.5f;
    //public static float speed2;
    private float maxSpeed = 40.0f;
    public static float acceleration = 1f;
    public static float acceleration2 = 0.001f;
    Vector3 EulerAngleVelocity;
    Vector3 originalEulerAngleVelocity;

    public static bool rotateBool = false;
    public static bool rotate2Bool = false;

    public static bool speedup = false;
    public static bool slowdown = false;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        BlackBoxRotate();
    }
    private void BlackBoxRotate()
    {
        if (rotateBool == true)
        {
            EulerAngleVelocity = new Vector3(speed, 0, 0);
            Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity);
            blackbox.MoveRotation(blackbox.rotation * deltaRotation);
            if (speed < maxSpeed && speedup ==true)
            {
                //speedup = true;
                //Debug.Log("speedup");
                speed = speed + acceleration;
                Debug.Log(speed);
            }
            else if (speed >= maxSpeed || slowdown == true)
            {
                //speed = maxSpeed;
                //acceleration = 0;
                speed -= acceleration2;
                speedup = false;
                slowdown = true;
                Debug.Log(speed);
            }

            if(speed <= 0)
            {
                speed = 0;
                acceleration2 = 0;
                rotateBool = false;
            }
            //Debug.Log(speed);
        }
    }

    //private void BlackBoxRotate2()
    //{
    //    Debug.Log(rotate2Bool);
    //    if (rotate2Bool == true)
    //    {
    //        Debug.Log("rotate2");
    //        EulerAngleVelocity = new Vector3(speed2, 0, 0);
    //        Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity);
    //        blackbox.MoveRotation(blackbox.rotation * deltaRotation);
    //        speed2 = speed2 - acceleration2;

    //        if (speed2 <= maxSpeed)
    //        {
    //            speed2 = speed2 - acceleration2;
    //        }
    //        if (speed2 < 0)
    //        {
    //            acceleration2 = 0;
    //            speed2 = 0;
    //        }
    //        Debug.Log(speed2);
    //    }
    //}
    //public static void SwitchToRotate2()
    //{
    //    rotateBool = false;
    //    rotate2Bool = true;
    //}
    public static void InitialState()
    {
        speed = 0.0f;
        acceleration = 0.1f;
        acceleration2 = 0.05f;
        rotateBool = false;
        rotate2Bool = false;
        speedup = true;
        slowdown = false;
        Debug.Log("slowdown:" + slowdown);
    }

    public void SlowDown()
    {
        speed -= acceleration2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RotateTest : MonoBehaviour
{
    public static int count;
    public static float thetaMax;
    public static bool isRotate = false;
    public float damping;
    public static float m_mass;
    public float omega;
    public float g;
    public float r;
    public float Xcm;
    float L=0.3f;
    float Icm;
    public static float delaysecond = 3f;
    float timer = 0f;
    int i=0;
    

    // Start is called before the first frame update
    void Start()
    {
        m_mass = DataSave.mass;
        Debug.Log(m_mass);
        //omega = Mathf.Sqrt((g*16.7f)-(damping*2/4*mass));
    }
    // Update is called once per frame
    void FixedUpdate()
    {


        if (isRotate == true)    
        {
            r = Mathf.Abs(transform.GetChild(0).localPosition.y) / 100;
            Xcm = r + 1.1f;
            Icm = (1 / 3) * (0.374f * Mathf.Pow(L, 2)) + 0.374f * Mathf.Pow(Xcm, 2) - 0.126f * Mathf.Pow(0.253f - Xcm, 2);
            omega = Mathf.Sqrt((g * m_mass * r) / (m_mass * Mathf.Pow(r, 2) + Icm));
            Debug.Log("omega: " + omega);
            timer += Time.deltaTime;
            i += 1;
            //if (i < 2)
            //{
            //    Debug.Log("pendulum start!!");
            //    Debuger.Log("pendulum start!!");
            //}

            
            if (thetaMax > 180)
            {
                thetaMax = thetaMax-360;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, thetaMax * Mathf.Exp((damping * timer / (-2 * m_mass))) * Mathf.Cos(0.1f * timer * 180 / Mathf.PI)), 5f);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, thetaMax * Mathf.Exp((damping * timer / (-2 * m_mass))) * Mathf.Cos(0.1f * timer * 180 / Mathf.PI)), 5f);
            }
            
            if(Timer.isrecorded == true)
            {
                if (Timer.iscounted == true & transform.rotation.z > 0)
                {
                    count += 1;
                    Timer.iscounted = false;
                    Debug.Log(count);
                }
                else if (transform.rotation.z < 0)
                {
                    Timer.iscounted = true;
                }
            }

        }

        if (isRotate == false)
        {
            timer = 0;
        }

    }
}

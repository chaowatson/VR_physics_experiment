using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoxTHRotation : MonoBehaviour
{
    public float T;
    public float Icm = 75.46f;
    public float R;
    public float g;
    public float theta;
    Vector3 initialRotation;
    float timer = 0f;
    float speed = 1f;
    int phase = 0;
    // Update is called once per frame

    void Start()
    {
        T = 2*Mathf.PI*Mathf.Sqrt((Icm+R*R)/(g*R));
        T = T*0.1f;
        Debug.Log(T);
        //speed = theta / 6;
        initialRotation = transform.eulerAngles;
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime*(4/T);
        if (timer > 1f)
        {
            phase++;
            phase %= 4;            //Keep the phase between 0 to 3.
            timer = 0f;
            //speed -= 0.1f;
            //if (speed < 0)
            //    speed = 0;
        }

        switch (phase)
        {
            case 0:
                transform.Rotate(0f, 0f, speed * (1 - timer));  //Speed, from maximum to zero.
                break;
            case 1:
                transform.Rotate(0f, 0f, -speed * timer);       //Speed, from zero to maximum.
                break;
            case 2:
                transform.Rotate(0f, 0f, -speed * (1 - timer)); //Speed, from maximum to zero.
                break;
            case 3:
                transform.Rotate(0f, 0f, speed * timer);        //Speed, from zero to maximum.
                break;
        }
    }

}

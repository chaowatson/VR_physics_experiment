using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MassBehavior : MonoBehaviour
{

    public GameObject photoGate;
    private float unityHeight;
    private float DeltaHeight;
    private float deltaT;
    public Text photoGateText;

    private void OnTriggerEnter(Collider other)
    {
        BlackBoxRotation.speedup = false;
        BlackBoxRotation.slowdown = true;
        //Debug.Log("slowdown");
        CalculateDeltaT();
    }

    private void OnMouseUp()
    {
        BlackBoxRotation.rotateBool = true;
 
        //BlackBoxRotation.rotate2Bool = false;

        unityHeight = gameObject.transform.position.y - photoGate.transform.position.y;
        DeltaHeight = unityHeight *2.5f ;
        //Debug.Log("unityHeight: "+ unityHeight);
        Debug.Log("DeltaHeight: " + DeltaHeight);
    }

    private void OnMouseDown()
    {
        BlackBoxRotation.InitialState();
    }
    //private void OnMouseDrag()
    //{
    //    unityHeight = gameObject.transform.position.y - photoGate.transform.position.y;
    //    DeltaHeight = unityHeight * 12;   //單位: 公分
    //    //Debug.Log("unityHeight: "+ unityHeight);
    //    Debug.Log("trueHeight: " + DeltaHeight);
    //}

    private void CalculateDeltaT()
    {
        if (DeltaHeight != 0 && DeltaHeight > 0)
        {
            // slow
            if (DeltaHeight < 8)
            {
                deltaT = DeltaHeight * 0.01f * (-1796.1f) + 279.8f;         //單位: 毫秒
                deltaT = Mathf.Round(deltaT * 10) / 10;                     //取小數第一位
                photoGateText.text = deltaT.ToString()+"ms";
                Debug.Log("deltaT1: " + deltaT);
            }
            else if (DeltaHeight < 23)
            {
                deltaT = Random.Range(142f, 148f);                          //單位: 毫秒
                deltaT = Mathf.Round(deltaT * 10) / 10;                     //取小數第一位
                photoGateText.text = deltaT.ToString() + "ms";
                Debug.Log("deltaT2: " + deltaT);
            }

            // fast
            else
            {
                deltaT = DeltaHeight * 0.01f * (-197.58f) + 178.72f;        //單位: 毫秒
                deltaT = Mathf.Round(deltaT * 10) / 10;                     //取小數第一位
                photoGateText.text = deltaT.ToString() + "ms";
                Debug.Log("deltaT3: " + deltaT);
            }

        }
    }

}

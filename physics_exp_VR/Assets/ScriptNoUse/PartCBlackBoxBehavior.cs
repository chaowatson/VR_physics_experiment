using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCBlackBoxBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blackBox;
    public float T1 = 1.109f;
    bool counterclockwise = true;
    bool clockwise = false;
    // Update is called once per frame

    void Start()
    {
    }
    void Update()
    {
        BlackBoxOscillate();
    }

    public void BlackBoxOscillate()
    {
        if (transform.rotation.z < (5 * Time.deltaTime * T1 * 0.25f) && counterclockwise == true)
        {
            transform.Rotate(0, 0, 5*Time.deltaTime*T1);
        }
        else if (transform.rotation.z > (5 * Time.deltaTime * T1 * 0.25f))
        {
            counterclockwise = false;
            clockwise = true;
        }
        else if (clockwise == true)
        {
            transform.Rotate(0, 0, -5 * Time.deltaTime*T1);
            if (transform.rotation.z< -(5 * Time.deltaTime * T1 * 0.25f))
            {
                counterclockwise = true;
            }
        }
    }
}

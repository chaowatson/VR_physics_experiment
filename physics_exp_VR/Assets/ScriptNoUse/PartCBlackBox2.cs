using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCBlackBox2 : MonoBehaviour
{
    public GameObject blackBox2;
    private float T2 = 1.019f;
    bool counterclockwise;
    bool clockwise;
    // Start is called before the first frame update
    void Start()
    {
        counterclockwise = true;
        clockwise = false;
    }

    // Update is called once per frame
    void Update()
    {
        BlackBox2Oscillate();
    }

    private void BlackBox2Oscillate()
    {
        if (transform.rotation.z < (5 * Time.deltaTime * T2 * 0.25f) && counterclockwise == true)
        {
            transform.Rotate(0, 0, 5 * Time.deltaTime * T2);
        }
        else if (transform.rotation.z > (5 * Time.deltaTime * T2 * 0.25f))
        {
            counterclockwise = false;
            clockwise = true;
        }
        else if (clockwise == true)
        {
            transform.Rotate(0, 0, -5 * Time.deltaTime * T2);
            if (transform.rotation.z < -(5 * Time.deltaTime * T2 * 0.25f))
            {
                counterclockwise = true;
            }
        }
    }
}

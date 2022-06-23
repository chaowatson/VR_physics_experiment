using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject mass;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = mass.transform.position;
        originalRotation = mass.transform.rotation;
    }

    //public void ResetBlackBox()
    //{
    //    mass.transform.position = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);
    //    mass.transform.rotation = new Quaternion(originalRotation.x, originalRotation.y, originalRotation.z, originalRotation.w);
    //}

    void Update()
    {
        if (mass.transform.position.y < 0 | mass.transform.position.x > originalPosition.x+2 | mass.transform.position.x < originalPosition.x-2)
        {
            mass.transform.position = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);
        }
    }
}

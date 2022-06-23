using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera mainCamera;
    private float moveSpeed = 10f;
    public float sensitivityX = 0.0001f;
    public float sensitivityY = 0.0001f;
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            mainCamera.transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            mainCamera.transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            mainCamera.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            mainCamera.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            mainCamera.transform.Rotate(new Vector3(0, -3*moveSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.E))
        {
            mainCamera.transform.Rotate(new Vector3(0, 3*moveSpeed * Time.deltaTime, 0));
        }
    }

}

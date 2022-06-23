using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Init
    public float moveSpeed = 1f;
    public Joystick jsMovement;
    public Vector3 direction;
    public float freeLookSensitivity = 3f;

    private float xMin, xMax, yMin, yMax;


    void Update()
    {
        // InputDirection can be used as per the need of your project
        direction = jsMovement.InputDirection;

        // If we drag the Joystick
        if (direction.magnitude != 0)
        {
            //Debug.Log("direction: "+direction);
            transform.position += direction * moveSpeed*0.1f;
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, xMin, xMax),
                5f,
                Mathf.Clamp(transform.position.z, yMin, yMax)
            );
        }
    }

    void Start()
    {
        // Initialization of boundaries
        xMax = Screen.width - 50;
        xMin = 50;
        yMax = Screen.height - 50;
        yMin = 5;
    }


    IEnumerator OnMouseDrag()
    {
        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
        transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);

        yield return new WaitForFixedUpdate();
    }
}

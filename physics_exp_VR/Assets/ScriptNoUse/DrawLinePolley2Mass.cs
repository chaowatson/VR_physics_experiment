using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLinePolley2Mass : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 position;
    public GameObject startPosition;
    public GameObject endPosition;

    // Start is called before the first frame update


    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.3f;
        lineRenderer.endWidth = 0.3f;

        position = new Vector3(endPosition.transform.position.x,startPosition.transform.position.y,startPosition.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, position);
        lineRenderer.SetPosition(1, endPosition.transform.position);
    }
}

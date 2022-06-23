using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLinePolley2Polley : MonoBehaviour
{
    public GameObject polley1;
    public GameObject polley2;
    public GameObject Base;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.3f;
        lineRenderer.endWidth = 0.3f;

        Vector3 startPosition = new Vector3(polley1.transform.position.x + 0.15f,
            polley1.transform.position.y,
            polley1.transform.position.z);

        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, polley2.transform.position);
        lineRenderer.SetPosition(2, Base.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

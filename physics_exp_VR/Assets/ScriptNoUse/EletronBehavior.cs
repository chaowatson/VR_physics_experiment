using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletronBehavior : MonoBehaviour
{
    public GameObject Q;
    public GameObject smallq;
    public LineRenderer lineRenderer;
    public List<Vector3> positionList = new List<Vector3>();
    //Vector3 position;
    Vector3 start;
    Vector3 end;
    private float m_a = 0.005f;
    private float m_b;
    private float m_c;
    private float scatterangle;
    private float angle2;
    private float deltax;
    private float deltay;
    private bool isSensed = false;
    private bool isScatrered = false;
    private SpriteRenderer mySpriteRenderer;
    private MeshRenderer meshRenderer;
    Vector3 m_o;
    Vector3 orginPosition;

    // Start is called before the first frame update
    void Start()
    {
        orginPosition = smallq.transform.position;
 
        //m_b = transform.position.x - Q.transform.position.x;
        m_b = Mathf.Sqrt(Mathf.Pow((smallq.transform.position.x - Q.transform.position.x), 2) +
                Mathf.Pow((smallq.transform.position.y - Q.transform.position.y), 2));
        if (Q.transform.position.x > transform.position.x)
        {
            m_b = -m_b;
        }
        m_c = Mathf.Sqrt(m_a * m_a + m_b * m_b);
        //m_o = new Vector3(Q.transform.position.x - Mathf.Sqrt(m_c * m_c - m_b * m_b), Q.transform.position.y + m_b, 0);
        scatterangle = 2 * Mathf.Atan((m_a / m_b));

        deltax = smallq.transform.position.x - Q.transform.position.x;
        deltay = smallq.transform.position.y - Q.transform.position.y;
        angle2 = Mathf.Atan(deltay / deltax) * (180 / Mathf.PI);
        //Debug.Log("angle2: " + angle2);


        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.startWidth = 0.02f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DrawLine();
        if (isSensed == false)
        {
            if (isScatrered == false)
                transform.Translate(0, 0, 0.05f);
            if (transform.position.z > Q.transform.position.z - Mathf.Sqrt(m_c * m_c - m_b * m_b) - 0.05f || isScatrered == true )
            {
                isScatrered = true;
                transform.localEulerAngles = new Vector3(0, scatterangle * (180 / Mathf.PI), 0);
                transform.Translate(0, deltay/ Mathf.Sqrt(Mathf.Pow(deltax, 2) + Mathf.Pow(deltay, 2)) * 0.05f, 0.05f);
                //Debug.Log("angle: " + scatterangle * (180 / Mathf.PI));
            }
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hit");
        //mySpriteRenderer = GetComponent<SpriteRenderer>();
        //mySpriteRenderer.color = Color.green;
        isSensed = true;
        transform.Translate(0, 0, 0);
    }

    public void DrawLine()
    {
        Vector3 pt = transform.position;
        if (positionList.Count > 0 && (pt - lastPoint).magnitude < 0.1f)
            return;
        if (pt != new Vector3(0, 0, 0))
            positionList.Add(pt);

        lineRenderer.positionCount = positionList.Count;
        if (positionList.Count > 0)
            lineRenderer.SetPosition(positionList.Count - 1, lastPoint);
    }

    public Vector3 lastPoint
    {
        get
        {
            if (positionList == null)
                return Vector3.zero;
            return (positionList[positionList.Count - 1]);
        }
    }

    public void ResetPosition()
    {
        transform.position = orginPosition;
        transform.localEulerAngles = new Vector3(0, 0, 0);
        isScatrered = false;
        //transform.Translate(0, 0, 0);
    }
}

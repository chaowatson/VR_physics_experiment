using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObnject : MonoBehaviour
{
    public GameObject blackbox;
    public GameObject needle;
    public GameObject Base;
    public GameObject stopwatch;
    public GameObject ruler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBlackBox()
    {
        if(CombineTest.blackboxNeedleCombined == false)
        {
            blackbox.SetActive(true);
            blackbox.transform.parent = null;
            blackbox.AddComponent<RSMouseDrag>();
            blackbox.transform.position = new Vector3(148.58f, 5.008287f, 88.17f);
        }

    }
    public void CreateBase()
    {
        Base.SetActive(true);
        needle.SetActive(true);
        base.transform.position = new Vector3(150.3557f, 4.44581f, 88.54f);
    }

    public void CreateStopWatch()
    {
        stopwatch.SetActive(true);
        stopwatch.transform.position = new Vector3(149.74f, 4.7f, 90.01f);
    }

    public void CreateRuler()
    {
        ruler.SetActive(true);
        ruler.transform.position = new Vector3(149.359f, 4.8f, 89.45f);
    }
}

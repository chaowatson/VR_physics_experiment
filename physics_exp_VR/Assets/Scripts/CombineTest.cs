using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineTest : MonoBehaviour
{
    public static bool blackboxNeedleCombined=false;
    public static bool needleBaseCombined = false;
    public GameObject blackboxTH;
    public GameObject blackbase;
    public GameObject blackboxUncombined;
    float distance;
    float distance2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(blackboxTH.transform.position, blackboxUncombined.transform.position);
        distance2 = Vector2.Distance(blackbase.transform.position, transform.position);

        blackboxTH.transform.localPosition = new Vector3(blackbase.transform.position.x + 0.004f, blackbase.transform.position.y, blackbase.transform.position.z - 0.4f);
        if (transform.tag == "blackbox-uncombined"& distance<1f)
        {
            //blackboxNeedleCombined = true;
            //GameObject parent = GameObject.Find("blackbox-combined");
            blackboxTH.GetComponent<BoxCollider>().enabled = true;
            transform.parent = blackboxTH.transform;
            transform.localPosition = new Vector3(0, transform.localPosition.y, -0.3f);
            Destroy(transform.GetComponent < RSMouseDrag > ());


        }
        //if (transform.name == "blackbox-combined"& distance2 < 1f)
        //{
        //    blackboxTH.transform.position = new Vector3(blackbase.transform.position.x, blackbase.transform.position.y + 0.1f, blackbase.transform.position.z - 1);
        //}

        //        GameObject bb_combined = GameObject.Find("blackbox-combined(Clone)");
        //GameObject bb = GameObject.Find("base(Clone)");
        //bb_combined.transform.position = new Vector3(bb.transform.position.x, bb.transform.position.y + 0.1f, bb.transform.position.z - 1);
    }
}

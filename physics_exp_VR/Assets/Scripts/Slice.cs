using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slice : MonoBehaviour
{
    public GameObject source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //將Souce切割，傳入的第一個參數?切割的位置（即刀片的位置），傳入的第二個參數?切割面的法向量（即刀片表面的法向量）
            SlicedHull hull = source.Slice(transform.position, transform.up);

            //創建把source切割以後的上半部分物體
            hull.CreateUpperHull(source);
            //創建把source切割以後的下半部分物體
            hull.CreateLowerHull(source);

            //因?是新建切出來兩個物體，因此要把原來的物體關閉
            source.SetActive(false);
        }
    }
}

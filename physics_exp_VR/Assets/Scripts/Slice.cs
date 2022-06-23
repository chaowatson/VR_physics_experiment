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
            //�NSouce���ΡA�ǤJ���Ĥ@�ӰѼ�?���Ϊ���m�]�Y�M������m�^�A�ǤJ���ĤG�ӰѼ�?���έ����k�V�q�]�Y�M�������k�V�q�^
            SlicedHull hull = source.Slice(transform.position, transform.up);

            //�Ыا�source���ΥH�᪺�W�b��������
            hull.CreateUpperHull(source);
            //�Ыا�source���ΥH�᪺�U�b��������
            hull.CreateLowerHull(source);

            //�]?�O�s�ؤ��X�Ө�Ӫ���A�]���n���Ӫ���������
            source.SetActive(false);
        }
    }
}

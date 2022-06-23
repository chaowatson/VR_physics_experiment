using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSMouseDrag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator OnMouseDown()
    {
        //BlackBoxRotation.InitialState();
        //�N����ѥ@�ɮy�Шt��Ƭ��ù��y�Шt�A��vector3 ���c���ܼ�ScreenSpace�x�s�A�H�Ψө��T�ù��y�ШtZ�b����m
        Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);
        //�����F��ӨB�J�A1�ѩ�ƹ����y�Шt�O2�����A�ݭn��Ʀ�3�����@�ɮy�Шt�A2�u���T�������p�U�~��ӭp��ƹ���m�P���骺�Z���Aoffset�Y�O�Z��
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z));
        //Debug.Log("down");
        //��ƹ�������U��
        while (Input.GetMouseButton(0))
        {
            if( CombineTest.blackboxNeedleCombined == false)
            {
                //�o��{�b�ƹ���2���y�Шt��m
                Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z);
                //�N��e�ƹ���2����m��Ʀ��T������m�A�A�[�W�ƹ������ʶq
                Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
                //CurPosition�N�O�������Ӫ����ʦV�q�ᵹtransform��position�ݩ�
                transform.position = CurPosition;
                yield return new WaitForFixedUpdate();
            }
  
        }
    }

}

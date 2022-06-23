using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;
public class TouchRotete : MonoBehaviour
{
    Vector3 startPosition;
    IEnumerator OnMouseDown()
    {

        startPosition = Input.mousePosition;
        yield return new WaitForFixedUpdate();

    }
    IEnumerator OnMouseDrag()
    {
        Vector3 mouseMove = Input.mousePosition - startPosition;
        //BlackBoxRotation.InitialState();
        //�N����ѥ@�ɮy�Шt��Ƭ��ù��y�Шt�A��vector3 ���c���ܼ�ScreenSpace�x�s�A�H�Ψө��T�ù��y�ШtZ�b����m
        Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);

 
        //�����F��ӨB�J�A1�ѩ�ƹ����y�Шt�O2�����A�ݭn��Ʀ�3�����@�ɮy�Шt�A2�u���T�������p�U�~��ӭp��ƹ���m�P���骺�Z���Aoffset�Y�O�Z��
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z));
        //Debug.Log("down");
        //��ƹ�������U��

        while (Input.GetMouseButton(0))
        {
            mouseMove = new Vector3(Mathf.Clamp(mouseMove.x, -90, 90), Mathf.Clamp(mouseMove.y, -16 * 3, 0), mouseMove.z);
            transform.localEulerAngles = new Vector3(0, 0, mouseMove.x);
            transform.GetChild(0).transform.localPosition = new Vector3(transform.GetChild(0).transform.localPosition.x, mouseMove.y *(1/3f), transform.GetChild(0).transform.localPosition.z);
            //if (transform.GetChild(1).transform.localPosition.y < -20)
            //{
            //    transform.GetChild(1).transform.localPosition = new Vector3(transform.GetChild(1).transform.localPosition.x, 0, transform.GetChild(1).transform.localPosition.z);
            //}

            RotateTest.thetaMax = transform.localEulerAngles.z;
            RotateTest.isRotate = false;

            yield return new WaitForFixedUpdate();

        }
    }

    IEnumerator OnMouseUp()
    {
        RotateTest.isRotate = true;
        StreamWriter sw = new StreamWriter("playerlog.txt", true);
        if (RotateTest.thetaMax > 180)
        {
            RotateTest.thetaMax = RotateTest. thetaMax - 360;
        }
        sw.WriteLine("RotateAngle: " + RotateTest.thetaMax.ToString());

        sw.Close();

        yield return new WaitForFixedUpdate();
    }
}



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
        //將物體由世界座標系轉化為螢幕座標系，由vector3 結構體變數ScreenSpace儲存，以用來明確螢幕座標系Z軸的位置
        Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);

 
        //完成了兩個步驟，1由於滑鼠的座標系是2維的，需要轉化成3維的世界座標系，2只有三維的情況下才能來計算滑鼠位置與物體的距離，offset即是距離
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z));
        //Debug.Log("down");
        //當滑鼠左鍵按下時

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



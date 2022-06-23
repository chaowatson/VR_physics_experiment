using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    void Update()
    {

    }
    IEnumerator OnMouseDown()
    {
        //BlackBoxRotation.InitialState();
        //將物體由世界座標系轉化為螢幕座標系，由vector3 結構體變數ScreenSpace儲存，以用來明確螢幕座標系Z軸的位置
        Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);
        //完成了兩個步驟，1由於滑鼠的座標系是2維的，需要轉化成3維的世界座標系，2只有三維的情況下才能來計算滑鼠位置與物體的距離，offset即是距離
        //Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z));
        //Debug.Log("down");
        //當滑鼠左鍵按下時
        while (Input.GetMouseButton(0))
        {
            //得到現在滑鼠的2維座標系位置
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, ScreenSpace.y, ScreenSpace.z);
            //將當前滑鼠的2維位置轉化成三維的位置，再加上滑鼠的移動量
            Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace);
            //CurPosition就是物體應該的移動向量賦給transform的position屬性
            transform.position = CurPosition;
            yield return new WaitForFixedUpdate();
        }
    }
    //private void OnMouseUp()
    //{
    //    BlackBoxRotation.rotateBool = true;
    //    //BlackBoxRotation.rotate2Bool = false;
    //}

}

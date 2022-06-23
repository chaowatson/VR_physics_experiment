using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO; 
using UnityEngine.UI;


public class DataSave : MonoBehaviour
{
    int i=0;

    public static float mass;
    public  InputField schoolInput;
    public  InputField numberInput;
    //string fullPath = "APPApplication.persistentDataPath";
    [System.Serializable]
    public class Data
    {
        public List<string> equip;
    }

    [System.Serializable]
    public class ObjectList
    {
        public Data datalist ;
    }
    public ObjectList objects = new ObjectList();

    // Start is called before the first frame update
    private void Awake()
    {


    }
    void Start()
    {
        ////Debug.Log(Application.persistentDataPath);
        //StreamWriter sw = new StreamWriter("playerlog.txt", true);
        StreamWriter sw = new StreamWriter("playerlog.txt", false);
        mass = 0.096f + UnityEngine.Random.Range(1, 10) * 0.0001f;
        sw.WriteLine(main.schoolName + ",");
        sw.WriteLine(main.testNumber + ",");
        sw.WriteLine("mass: " + mass);
        sw.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            i += 1;
            //Debug.Log("hit");

            objects.datalist.equip.Add(this.gameObject.name);
            WritePlayerLog();
            //FileStream fs = new FileStream("playerlog.txt", FileMode.CreateNew); 
        }
    }
    private void OnMouseUp()
    {
        //WritePlayerLog();
    }

    public void WritePlayerLog()
    {
        StreamWriter sw = new StreamWriter("playerlog.txt", true);
        //Debug.Log(sw);
        //if (File.Exists("playerlog.txt"))
        //{
        //    Debug.Log("finds file");
        //}
        sw.WriteLine(objects.datalist.equip[i - 1] + ",");
        sw.WriteLine(DateTime.Now.ToString() + ",");
 
        sw.Close();
    }

    public static void WritePeriod()
    {   
        StreamWriter sw = new StreamWriter("playerlog.txt", true);
        sw.WriteLine("Period: " + Timer.secondsCount.ToString() + ",");

        sw.Close();
    }
    public static void WriteTimes()
    {
        StreamWriter sw = new StreamWriter("playerlog.txt", true);
        sw.WriteLine("Recorded rotate times: " + RotateTest.count.ToString() + ",");
        sw.Close();
    }
    public void WriteStudenrInfo()
    {
        StreamWriter sw = new StreamWriter("playerlog.txt", true);
        sw.WriteLine(schoolInput.text + ",");
        sw.WriteLine(numberInput.text + ",");
        sw.Close();

    }
}

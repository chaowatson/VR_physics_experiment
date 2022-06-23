using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TableCreate : MonoBehaviour
{
    string filename = "";
    public int i;
    int j;
    BinaryFormatter bf = new BinaryFormatter();
    [System.Serializable]

    public class datatable
    {
        public string times;
        public float T;
    }
    [System.Serializable]
    public class ExperimentList
    {
        public datatable[] datatable;
    }

    public ExperimentList myExperimentList = new ExperimentList();
    public Text textPrefab;
    public Text timesPrefab;
    public InputField inputField;
    public Image dataTable;
    // Start is called before the first frame update
    void Start()
    {
        i = -1;


        filename = Application.dataPath + "/test.csv";
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("times,T");
        tw.Close();

    }
    public void EnterText()
    {
        TextWriter tw = new StreamWriter(filename, true);
        Stream s = File.Open(Application.dataPath + "/DataTable.ept", FileMode.Create);

        j += 25;
        i += 1;
        textPrefab.text = inputField.text.Trim();
        timesPrefab.text = (i+1).ToString();
        Instantiate(textPrefab, new Vector3(textPrefab.transform.position.x+820, textPrefab.transform.position.y+580 - j, textPrefab.transform.position.z), textPrefab.transform.rotation, dataTable.transform) ;
        Instantiate(timesPrefab, new Vector3(textPrefab.transform.position.x + 650, textPrefab.transform.position.y + 580 - j, textPrefab.transform.position.z),timesPrefab.transform.rotation, dataTable.transform);
        //Instantiate(textPrefab, playerCanvas.transform,false);


        if (myExperimentList.datatable.Length >= 0)
        {
            myExperimentList.datatable[i].times = (i + 1).ToString();
            myExperimentList.datatable[i].T = float.Parse(textPrefab.text);


            bf.Serialize(s, myExperimentList.datatable[i].times + ","+ myExperimentList.datatable[i].T + ',');
            Debug.Log("¼g¤J¦¨¥\");
            s.Close();
            //tw.WriteLine(myExperimentList.datatable[i].times + "," + myExperimentList.datatable[i].T + ",");

        }
    }

    public void DeleteTable()
    {
        // File.Delete("@C: /Users/laimm/Desktop/My project/Assets/DataTable.ept");
        foreach (Transform child in dataTable.transform) GameObject.Destroy(child.gameObject);
        i = -1;
        j = 0;
    }
}

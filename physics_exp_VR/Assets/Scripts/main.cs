using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class main : MonoBehaviour
{
    public  InputField schoolInput;
    public  InputField numberInput;

    public static string schoolName;
    public static string testNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        schoolName = schoolInput.text;
        testNumber = numberInput.text;
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(schoolInput);
        DontDestroyOnLoad(numberInput);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text timerText2;
    public bool startUpdate = false;
    public static bool isrecorded=false;
    public static bool iscounted;
    public static float secondsCount;
    private int minuteCount;
    private int hourCount;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startUpdate == true)
        {
            UpdateTimerUI();
        }
    }

    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = minuteCount + "0:" + secondsCount.ToString("0.00")/* + "s"*/;
        timerText2.text = minuteCount + "m:" + secondsCount.ToString("0.00") + "s";
}

    public void StartCountUp()
    {
        startUpdate = true;
        isrecorded = true;
        iscounted = true;
    }

    public void PauseCountUp()
    {
        startUpdate = false;
        isrecorded = false;
        DataSave.WritePeriod();
        DataSave.WriteTimes();

    }
    public void ResetTimerUI()
    {
        startUpdate = false;
        secondsCount = 0;
        timerText.text = minuteCount + "0:" + (float)secondsCount /*+ "s"*/;
        timerText2.text = minuteCount + "m:" + (float)secondsCount + "s";
    }
    //public void CountUp()
    //{
    //    secondsCount = 0;
    //    for (int secondsCount =0; secondsCount >=0; secondsCount ++)
    //    {
    //        if (secondsCount > 59)
    //        {
    //            minuteCount += 1;
    //            secondsCount = 0;
    //        }
    //        timerText.text = minuteCount + "m:" + (int)secondsCount + "s";
    //    }
    //}

    //public void StartTimer()
    //{
    //    InvokeRepeating("CountUp", 0, 1);
    //}
    public void OnOff()
    {
        i += 1;
        this.enabled = true;
        if (i % 2 == 1)
        {
            GameObject.Find("stopwatch-img").SetActive(true);
            GameObject.Find("time-text").SetActive(true);
            GameObject.Find("timer-btn").SetActive(true);
            GameObject.Find("pause-btn").SetActive(true);
            GameObject.Find("reset-btn").SetActive(true);
        }

        else
        { 
            GameObject.Find("stopwatch-img").SetActive(false);
            GameObject.Find("time-text").SetActive(false);
            GameObject.Find("timer-btn").SetActive(false);
            GameObject.Find("pause-btn").SetActive(false);
            GameObject.Find("reset-btn").SetActive(false);
        }

    }
}
   

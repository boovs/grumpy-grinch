using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    [SerializeField] private TimerSO timer;
    [SerializeField] private TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "0:00.000";
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Active) 
        {
            int minutes = (int) timer.ElapsedTime / 60 % 60;
            float seconds = timer.ElapsedTime % 60;

            timer.ElapsedTime += Time.deltaTime;
            
            timerText.text = seconds < 10 ? minutes + ":0" + seconds.ToString("F3") : minutes + ":" + seconds.ToString("F3");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    [SerializeField] private float startTime = 0f;
    [SerializeField] private Text timerText;

    private float timer = 0f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        timer = startTime;

        do
        {
            timer -= Time.deltaTime;
            FormatTimerText();

            yield return null;
        } 
        while (timer > 0);
    }

    private void FormatTimerText()
    {
        int minutes = (int) (timer / 60) % 60;
        int seconds = (int) (timer % 60);

        timerText.text = "";

        if (minutes > 0)
        {
            timerText.text += minutes + "m ";
        }

        if (seconds > 0)
        {
            timerText.text += seconds + "s ";
        }
    }
    


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
<<<<<<< HEAD
{
=======
{
>>>>>>> main
    private float startTime = 180f;
    [SerializeField] private Text timerText;

    [HideInInspector] public float timer = 0f;
    public GameObject losePanel;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if (timer < 1)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    public IEnumerator Timer()
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

    public void FormatTimerText()
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

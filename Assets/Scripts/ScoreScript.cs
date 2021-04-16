using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    [HideInInspector] public int highScore;
    [HideInInspector] public int score;
    public GameObject highScorePanel;

    // Start is called before the first frame update
    void Start()
    {
        highScore = 1000;
        
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (score >= highScore)
        {
            highScorePanel.SetActive(true);
            HighScore();
        }
    }


    public void Furniture()
    {
        score += 500;
        scoreText.text = score.ToString();
    }

    public void Rubbish()
    {
        score += 50;
        scoreText.text = score.ToString();
    }

    public void RubbishBin()
    {
        score += 1000;
        scoreText.text = score.ToString();
    }
    
    public void HighScore()
    {
        StartCoroutine(WaitForSec());
            
        
       
    }
    
    
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5f);
        highScorePanel.SetActive(false);
        Destroy(highScorePanel);
    }
    

}

   

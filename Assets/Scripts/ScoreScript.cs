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
    private bool highscore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = 1500;

        highscore = true;
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (score >= highScore && highscore == true)
        {
            highScorePanel.SetActive(true);
            highscore = false;
            HighScore();
        }
    }


    public void Furniture()
    {
        score += 100;
        scoreText.text = score.ToString();
    }

    public void Rubbish()
    {
        score += 50;
        scoreText.text = score.ToString();
    }

    public void RubbishBin()
    {
        score += 100;
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

   

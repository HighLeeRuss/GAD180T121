using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    [HideInInspector] public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
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

}

   

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private ScoreScript score;
    public GameObject nexLevel;
    private AudioSource source;

    private void Start()
    {
       score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }

   private void OnTriggerEnter2D(Collider2D col)
   {
       if(col.gameObject.tag == "Player" && score.score >= score.highScore)
       {
           nexLevel.SetActive(true);
           Time.timeScale = 0;
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       }
   }
}

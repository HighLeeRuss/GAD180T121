using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : MonoBehaviour
{

    private RubbishBar rubbishBar;
    private Animator playerAnim;
    private Player player;
    private ScoreScript addScore;
    private AudioSource source;


    private void Start()
    {
        rubbishBar = GameObject.FindGameObjectWithTag("RubbishBar").GetComponent<RubbishBar>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        addScore = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        source = GetComponent<AudioSource>();
    }


    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            if (!rubbishBar.rubbishFull)
            {
                rubbishBar.SetRubbish(1);
                addScore.Rubbish();
                if (player != null)
                {
                    playerAnim.SetBool("isSucking", true); 
                }
                
                source.Play();
                StartCoroutine(DeathTimer());
                
            }
            else if (rubbishBar.rubbishFull)
            {
                print("cant do it homie");
                playerAnim.SetBool("isSucking", false);
            }
        }
    }



    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(.2f);
        if (player != null)
        {
            playerAnim.SetBool("isSucking", false);
        }

        Destroy(gameObject);
   }
}

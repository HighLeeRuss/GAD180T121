using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : MonoBehaviour
{

    private RubbishBar rubbishBar;
    private Animator playerAnim;
    private Player player;


    private void Awake()
    {
        rubbishBar = GameObject.FindWithTag("RubbishBar").GetComponent<RubbishBar>();
        playerAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }


    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            print("i have found rubbish");
            Debug.Log(rubbishBar.rubbishFull + "rubbish full");
            if (!rubbishBar.rubbishFull)
            {
                rubbishBar.SetRubbish(1);
                playerAnim.SetBool("isSucking", true);
                //playerAnim.SetBool("isSucking", false)
                StartCoroutine(DeathTimer());
                
            }
            else if (rubbishBar.rubbishFull)
            {
                print("cant do it homie");
                playerAnim.SetBool("isSucking", false);
            }
        }
    }

   //public void OnTriggerExit2D(Collider2D col)
   //{
   //    if (col.gameObject.tag == "Player")
   //    {
   //        playerAnim.SetBool("isSucking", false);
   //    }
   //}

   IEnumerator DeathTimer()
   {
       yield return new WaitForSeconds(.2f);
       playerAnim.SetBool("isSucking", false);
       
       Destroy(gameObject);
   }
}

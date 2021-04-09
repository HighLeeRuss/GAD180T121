using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Furniture : MonoBehaviour
{
   private GameObject player;
   private Player playerScript;
   private RubbishBar rubbishBar;
   private bool pickUp = false;
   private Animator anim;
   private ScoreScript addScore;
   
   
   
   
   





   private void Awake()
   {
      playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
      rubbishBar = GameObject.FindWithTag("RubbishBar").GetComponent<RubbishBar>();
      anim = GetComponent<Animator>();
      addScore = GameObject.FindWithTag("Score").GetComponent<ScoreScript>();
      
      
      

      if (player == null)
      {
         player = GameObject.FindGameObjectWithTag("Player");
      }
      

   }

   private void Update()
   {
      if (pickUp)
      {
         transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
         anim.SetBool("isSucked", true);
         StartCoroutine(MoveToPlayer());
         rubbishBar.SetRubbish(5);
         GetComponent<BoxCollider2D>().enabled = false;
         addScore.Furniture();
         
         
      }
   }


   public void OnTriggerStay2D(Collider2D col)
   {
      if (col.gameObject.tag == "Player" && (!rubbishBar.rubbishFull && rubbishBar.slider.value <= 5))
      {
         Debug.Log(col.name);
         pickUp = true;
      }
      else if (col.gameObject.tag == "Player" && (rubbishBar.rubbishFull || rubbishBar.slider.value > 5))
      {
         print("you full sucka");
      }
   }

   public void OnTriggerExit2D(Collider2D c)
   {
      if (c.gameObject.tag == "Player")
      {
         pickUp = false;
      }
   }

   IEnumerator MoveToPlayer()
   {
      float alpha = 0.0f;
      float maxAlpha = 1.0f;
      while (alpha < maxAlpha)
      {
         transform.position = Vector2.Lerp(transform.position, player.transform.position, alpha);
         alpha += Time.deltaTime;
         yield return null;
      }
   }
   
}

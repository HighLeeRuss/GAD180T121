using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
   public GameObject player;
   private Player playerScript;
   private RubbishBar rubbishBar;
   private bool pickUp = false;
   private Animator anim;
   
   





   private void Awake()
   {
      playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
      rubbishBar = GameObject.FindWithTag("RubbishBar").GetComponent<RubbishBar>();
      anim = GetComponent<Animator>();
      //if (player == null)
      //{
      //   player = GameObject.FindGameObjectWithTag("Player");
      //}
      

   }

   private void Update()
   {
      if (pickUp)
      {
         if (Input.GetKeyDown(KeyCode.E))
         {
            StartCoroutine(MoveToPlayer());
            anim.SetBool("isSucked", true);
            rubbishBar.SetRubbish(5);
            
         }
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

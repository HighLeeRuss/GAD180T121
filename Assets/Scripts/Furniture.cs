using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
   private Player playerScript;
   private RubbishBar rubbishBar;
   private bool pickUp = false;


   private void Awake()
   {
      playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
      rubbishBar = GameObject.FindWithTag("RubbishBar").GetComponent<RubbishBar>();
   }

   private void Update()
   {
      if (pickUp)
      {
         if (Input.GetKeyDown(KeyCode.E))
         {
            Destroy(gameObject);
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
}

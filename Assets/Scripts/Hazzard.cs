using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazzard : MonoBehaviour
{
  private Player playerScript;
  private RubbishBar rubbishBar;


  private void Awake()
  {
    playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
    rubbishBar = GameObject.FindWithTag("RubbishBar").GetComponent<RubbishBar>();
  }
  
  
  public void OnTriggerStay2D(Collider2D col)
  {
    if (col.gameObject.tag == "PlayerCollider")
    {
      playerScript.isStunned = true;
      playerScript.IsStunned();




    }
  }

 
}

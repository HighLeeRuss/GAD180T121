using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazzard : MonoBehaviour
{
  private Player playerScript;
  private RubbishBar rubbishBar;
  private Player player;


  private void Start()
  {
    playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    rubbishBar = GameObject.FindWithTag("RubbishBar").GetComponent<RubbishBar>();
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
  }
  
  
  public void OnTriggerStay2D(Collider2D col)
  {
    if (col.gameObject.tag == "PlayerCollider")
    {
      if (player != null)
      {
        playerScript.isStunned = true;
        playerScript.IsStunned();
      }
    }
  }

 
}

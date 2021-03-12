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
      print("i stunned");
      playerScript.speed = 0f;
      StartCoroutine(WaitForSec());
    }
  }

  IEnumerator WaitForSec()
  {
    yield return new WaitForSeconds(2f);
        
    if (rubbishBar.slider.value > 5)
    {
      playerScript.speed = 3.5f;
    }
    if (rubbishBar.slider.value >= 10)
    {
      playerScript.speed = 1f;
    }
    else
    {
      playerScript.speed = 4.5f;
    }
  }
}

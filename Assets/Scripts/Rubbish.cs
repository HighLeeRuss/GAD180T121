using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : MonoBehaviour
{

    private RubbishBar rubbishBar;


    private void Awake()
    {
        rubbishBar = GameObject.FindWithTag("RubbishBar").GetComponent<RubbishBar>();
    }


    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            print("i have found rubbish");
            Debug.Log(rubbishBar.rubbishFull + "rubbish full");
            if (!rubbishBar.rubbishFull)
            {
                Destroy(gameObject);
                rubbishBar.SetRubbish(1);
            }
            else if (rubbishBar.rubbishFull)
            {
                print("cant do it homie");
            }
        }
    }
}

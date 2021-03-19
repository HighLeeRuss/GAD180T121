using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBin : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Animator anim;
    private Player playerScript;
    private RubbishBar rubbishBar;
    private bool binFull = false;
    [HideInInspector] public int binCapacity;
    private bool contact = false;
    
    
   
    void Awake()
    {
        binCapacity = 20;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
        rubbishBar = GameObject.FindWithTag("RubbishBar").GetComponent<RubbishBar>();
        

    }

    // Update is called once per frame
    void Update()
    {

        if (contact)
        {
            if (Input.GetKeyDown(KeyCode.R) && binCapacity > 0 && rubbishBar.slider.value > 0)
            {

                rubbishBar.SetRubbish(-1);
                binCapacity -= 1;
                Debug.Log(binCapacity + "bin capacity");

                if (binCapacity == 0)
                {
                    binFull = true;
                }
            }
        }

        if (binFull)
        {
            anim.SetBool("isFull", true);
        }
    }

    public void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("contact");
            contact = true;
        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("left");
        contact = false;
    }
}

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
    private ScoreScript addScore;
    private AudioSource source;
    public AudioClip emptyBin;
    public AudioClip binFullAudio;



    void Awake()
    {
        binCapacity = 20;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
        rubbishBar = GameObject.FindWithTag("RubbishBar").GetComponent<RubbishBar>();
        addScore = GameObject.FindWithTag("Score").GetComponent<ScoreScript>();
        source = GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {

        if (contact)
        {
            if (rubbishBar.slider.value > 0)
            {
                transform.GetChild(3).gameObject.SetActive(true);
                anim.SetBool("rMash", true);
            
            }
            else
            {
                transform.GetChild(3).gameObject.SetActive(false);
                anim.SetBool("rMash", false);
            
            }
            
            if (Input.GetKeyDown(KeyCode.R) && binCapacity > 0 && rubbishBar.slider.value > 0)
            {
                //CheckContact();

                source.clip = emptyBin;
                source.Play();
                rubbishBar.SetRubbish(-1);
                binCapacity -= 1;
                Debug.Log(binCapacity + "bin capacity");

                if (binCapacity == 0)
                {
                    binFull = true;
                    
                    print("the bin is full");

                    addScore.RubbishBin();
                }
                
            }
        }

        if (binFull)
        {
            anim.SetBool("isFull", true);
            anim.SetBool("rMash", false);
            transform.GetChild(3).gameObject.SetActive(false);

        }
    }

    public void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            
            CheckContact();
        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("left");
        contact = false;
        transform.GetChild(3).gameObject.SetActive(false);
    }


    void CheckContact()
    {
        Debug.Log("contact");
        contact = true;
        
        if (binFull)
        {
            transform.GetChild(3).gameObject.SetActive(false);
            anim.SetBool("rMash", false);
        }
        else if (rubbishBar.slider.value > 0 && !binFull)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            anim.SetBool("rMash", true);
        }
    }

    void Audio()
    {
        source.clip = binFullAudio;
        source.Play();
    }
}

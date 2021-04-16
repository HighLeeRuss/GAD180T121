using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private AudioSource stunnedAudio;
    [HideInInspector] public Animator anim;
    //[HideInInspector] public Animator wheelAnim;

    
    [HideInInspector] public Vector2 moveInput;
    [HideInInspector] public Vector2 moveAmount;

    [HideInInspector] public RubbishBar rubbishBar;
    [HideInInspector] public bool isStunned;
    


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isStunned = false;
        rubbishBar = GameObject.FindWithTag("RubbishBar").GetComponent<RubbishBar>();
        stunnedAudio = GetComponent<AudioSource>();
        //wheelAnim = transform.GetChild(3).GetComponent<Animator>();



    }

    // Update is called once per frame
    public void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
        Debug.Log(moveInput);
        
        Debug.Log("player is stunned " + isStunned);
        
        
        

        if (moveAmount.magnitude != 0)
        {
            anim.SetBool("isMoving", true);
            //wheelAnim.SetBool("wheelsMoving", true);
            
            
        }
        else
        {
            anim.SetBool("isMoving", false);
            //wheelAnim.SetBool("wheelsMoving", false);

        }
        
        if (!isStunned)
        {
            anim.SetBool("isStunned", false);
            //stunnedAudio.Stop();
            speed = 4f;
            if (rubbishBar.slider.value > 5)
            {
                speed = 3f;
                if (rubbishBar.slider.value >= 10)
                {
                    speed = 2.5f;
                }
            }
        }
    }
    
    












    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void IsStunned()
    {
        if (isStunned)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            anim.SetBool("isStunned", true);
            speed = 0f;
            StartCoroutine(WaitForSec());
            
        }
       
    }
    
    
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3.5f);
        isStunned = false;
        transform.GetChild(2).gameObject.SetActive(false);
    }

    void Audio()
    {
        stunnedAudio.Play();
    }
    


  


  }
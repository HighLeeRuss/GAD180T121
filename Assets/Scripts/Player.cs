using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 moveAmount;

    public RubbishBar rubbishBar;
    [HideInInspector] public bool isStunned = false;
    


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if (isStunned)
        {
            speed = 0f;
        }
        else
        {
            speed = 4.5f;

            if (rubbishBar.slider.value > 5)
            {
                speed = 3.5f;

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


  


  }
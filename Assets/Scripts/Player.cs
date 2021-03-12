using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 moveAmount;

    private bool pickUp = false;
    public RubbishBar rubbishBar;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if (rubbishBar.slider.value > 5)
        {
            speed = 3.5f;
        }

        if (rubbishBar.slider.value >= 10)
        {
            speed = 1f;
        }
        
        
        
        if (Input.GetKeyDown("e") && !rubbishBar.rubbishFull)
        {
            rubbishBar.SetRubbish(1);
            if (rubbishBar.rubbishFull)
            {
                print("cant suck no more Gee");
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }


    
    
}
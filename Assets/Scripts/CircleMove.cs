using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float input;
    public float speed;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {

        input = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(input * speed, rb.velocity.y);

    }
}

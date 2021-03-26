using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    private Animator anim;
    private Player player;
    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.moveAmount.magnitude != 0)
        {
            anim.SetBool("wheelsMoving", true);
        }
        else
        {
            anim.SetBool("wheelsMoving", false);
        }
    }
}

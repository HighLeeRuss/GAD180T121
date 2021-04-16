using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_collision_script : MonoBehaviour
{
    public WheelMovement movement;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();

        }
    }
}
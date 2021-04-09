using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [HideInInspector] public Transform playerTransform;
    public float speed;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    
    // Start is called before the first frame update
    void Start()
    {
        minX = -5.85f;
        maxX = 6.18f;
        minY = -4.39f;
        maxY = 4.41f;
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        transform.position = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);

            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
        }
    }
}

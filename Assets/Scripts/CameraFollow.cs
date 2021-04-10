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
        minX = -3.89f;
        maxX = 8.03f;
        minY = -4.2f;
        maxY = 4.27f;
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

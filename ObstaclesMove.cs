using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMove : MonoBehaviour
{
    public static float moveSpeed = 7f;
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if(transform.position.x < -23f)
        {
            Destroy(gameObject);
        }
        
    }
}

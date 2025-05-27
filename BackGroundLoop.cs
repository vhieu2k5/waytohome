using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    public static float scrollSpeed = 7f;
    public float resetPositionX;
    public float startPositionX;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
        
        if(transform.position.x < resetPositionX)
        {
            Vector2 newPos = transform.position;
            newPos.x = startPositionX;
            transform.position = newPos;
        }
    }
}

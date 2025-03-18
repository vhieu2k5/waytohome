using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;

    public Animator anim;

    public int tocDo = 4;

    public float traiPhai;

    public bool isFacingRight = true;

    void Start()
    {
        
    }

    void Update()
    {
        traiPhai = Input.GetAxisRaw("Horizontal"); // A = -1, 0, D = 1 
        rb.velocity = new Vector2(tocDo * traiPhai, rb.velocity.y);

        if(isFacingRight = true && traiPhai == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if(isFacingRight = false && traiPhai == 1)
        {
            isFacingRight = true;
        }
        // Animation
        anim.SetFloat("dichuyen", Mathf.Abs(traiPhai));
    }
}

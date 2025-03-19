using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    public int tocDo = 4;
    public float jump = 7f; 
    public bool isFacingRight = true;
    public bool isGrounded; 

    public Transform groundCheck; 
    public LayerMask groundLayer; 

    void Update()
    {
        
        float traiPhai = Input.GetAxisRaw("Horizontal"); // A = -1, D = 1, Không bấm = 0
        rb.velocity = new Vector2(tocDo * traiPhai, rb.velocity.y);

        
        if (isFacingRight && traiPhai == -1)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (!isFacingRight && traiPhai == 1)
        {
            isFacingRight = true;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        // Animation
       // anim.SetFloat("dichuyen", Mathf.Abs(traiPhai));
      //  anim.SetBool("isJumping", !isGrounded);
    }
}

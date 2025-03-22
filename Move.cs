using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    public int tocDo = 4;

    public float jump = 5f;

    public bool isFacingRight = true;
    public bool isGrounded;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    void Update()
    {
        //  isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.1f, 0.01f), CapsuleDirection2D.Horizontal, 0.1f, groundLayer);

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }

        // Animation
        // anim.SetFloat("dichuyen", Mathf.Abs(traiPhai));
        //  anim.SetBool("isJumping", !isGrounded);
    }
}
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Runner : MonoBehaviour
{
    public float jumpForce = 7f;
    public float slideDuration;
    private bool isGrounded = true;
    private bool isSliding = false;
    public GameObject RestartMenu;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Vector2 originalSize;
    private Vector2 originalOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        originalSize = boxCollider.size;
        originalOffset = boxCollider.offset;

        RestartMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && !isSliding)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding && isGrounded)
        {
            StartCoroutine(Slide());
        }

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    IEnumerator Slide()
    {
        isSliding = true;

        boxCollider.size = new Vector2(originalSize.x, originalSize.y / 2);
        boxCollider.offset = new Vector2(originalOffset.x, originalOffset.y - originalSize.y / 4);

        yield return new WaitForSeconds(slideDuration);

        boxCollider.size = originalSize;
        boxCollider.offset = originalOffset;

        isSliding = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chaser"))
        {
            RestartMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

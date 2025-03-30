using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteController : MonoBehaviour
{
    public float flySpeed = 4f;
    public float moveSpeed = 3f;
    public float maxHeight = 5f;
    public Transform attachPoint;
    public StarSpawner starSpawner;

    private bool isFlying = false;
    private bool Ready = false;
    private Vector3 startPosition;
    private LineRenderer lineRenderer;

    void Start()
    {
        startPosition = transform.position;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (isFlying)
        {
            if (!Ready) // diều bay lên
            {
                if (transform.position.y < startPosition.y + maxHeight)
                {
                    transform.position += Vector3.up * flySpeed * Time.deltaTime;
                }
                else
                {
                    Ready = true;

                    if(starSpawner != null)
                    {
                        starSpawner.StartSpawning();
                    }
                }
            }
            else
            {
                float moveX = Input.GetAxis("Horizontal");
                float moveY = Input.GetAxis("Vertical");

                Vector3 movement = new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime;
                transform.position += movement;
            }

            if (attachPoint != null)
            {
                lineRenderer.SetPosition(0, attachPoint.position);
                lineRenderer.SetPosition(1, transform.position);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFlying = true;
            lineRenderer.enabled = true;
        }
        else if (other.CompareTag("Star"))
        {
            Destroy(other.gameObject); 
        }
    }
    public bool IsFlying()
        {
            return isFlying;
        }
    }

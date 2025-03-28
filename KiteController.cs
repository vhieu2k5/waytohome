using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteController : MonoBehaviour
{
    public float flySpeed = 2f;
    public float maxHeight = 5f;
    public Transform attachPoint;

    private bool isFlying = false;
    private Vector3 startPosition;
    private LineRenderer lineRenderer;
    void Start()
    {
        startPosition = transform.position;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;
    }

    // public float horizontalSpeedMultiplier = 0.5f;
    void Update()
    {
        if (isFlying)
        {
            if(transform.position.y < startPosition.y + maxHeight)
            {
                transform.position += Vector3.up * flySpeed * Time.deltaTime;
            }

            float moveInput = Input.GetAxis("Horizontal"); //A-D
            transform.position += Vector3.right * moveInput * flySpeed * Time.deltaTime;
            // * horizontalSpeedMultiplier.

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
    }

    public bool IsFlying()
    {
        return isFlying;
    }
}

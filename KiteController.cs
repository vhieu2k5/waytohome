using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteController : MonoBehaviour
{
    public float flySpeed = 4f;
    public float moveSpeed = 3f;
    public float maxHeight = 5f;
    public Transform attachPoint;   // diem gan day dieu
    public StarSpawner starSpawner; // sinh ra cac manh ki uc
    public CameraControl cameraControl; // dieu khien camera
    public Collider2D barrierCollider;  // ngăn chan đường

    private bool isFlying = false;
    private bool Ready = false; // kiểm tra đat đô cao max 
    private bool isFinished = false;    // thu thap đu manh ki uc ch?
    private Vector3 startPosition;  // lưu vtri ban đầu
    private LineRenderer lineRenderer;  // dây nối
    private int totalStars;
    private int collectedStars = 0;

    void Start()
    {
        startPosition = transform.position;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (isFlying && !isFinished)
        {
            if (!Ready) // Diều bay lên
            {
                if (transform.position.y < startPosition.y + maxHeight)
                {
                    transform.position += Vector3.up * flySpeed * Time.deltaTime;
                }
                else
                {
                    Ready = true;

                    if (starSpawner != null)
                    {
                        totalStars = starSpawner.StartSpawning();
                    }
                }
            }
            else // Điều khiển diều di chuyển
            {
                float moveX = Input.GetAxis("Horizontal");
                float moveY = Input.GetAxis("Vertical");

                Vector3 movement = new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime;
                transform.position += movement;
            }

            if (attachPoint != null)    // diem dau và diem cuoi cua dây diều
            {
                lineRenderer.SetPosition(0, attachPoint.position);
                lineRenderer.SetPosition(1, transform.position);
            }
        }
        else if (isFinished) 
        {
            transform.position += Vector3.up * flySpeed * Time.deltaTime;
            if (transform.position.y > startPosition.y + maxHeight + 3f)
            {
                Destroy(gameObject);
                cameraControl.SwitchToPlayerCamera(); 
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
            collectedStars++;

            if (collectedStars >= totalStars) 
            {
                isFinished = true;
                UnlockNextmap();
            }
        }
    }

    void UnlockNextmap()
    {
        if(barrierCollider != null)
        {
            barrierCollider.enabled = false;
        }
    }

    public bool IsFlying()
    {
        return isFlying;
    }
}

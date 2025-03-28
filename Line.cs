using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Transform attachPoint;
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if(attachPoint != null)
        {
            lineRenderer.SetPosition(0, attachPoint.position);
            lineRenderer.SetPosition(1, transform.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTrigger : MonoBehaviour
{
    public GuidePanel guideManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            guideManager.showGuide();
            Destroy(gameObject);
        }
    }
}

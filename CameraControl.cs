using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera kiteCamera;
    public KiteController kite;

    private bool isTrackingKite = false;

    // Update is called once per frame
    void Update()
    {
       if(kite != null && kite.IsFlying() && !isTrackingKite)
        {
            SwitchToKiteCamera();
        } 
    }

    void SwitchToKiteCamera()
    {
        playerCamera.Priority = 0;
        kiteCamera.Priority = 1;
        isTrackingKite = true;
    }
}

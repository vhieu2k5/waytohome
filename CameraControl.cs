using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera kiteCamera;
    public KiteController kite; // tham chieu

    private bool isTrackingKite = false;

    void Update()
    {
        if (kite != null && kite.IsFlying() && !isTrackingKite)
        {
            SwitchToKiteCamera();
        }
    }

    public void SwitchToKiteCamera()
    {
        playerCamera.Priority = 0;
        kiteCamera.Priority = 1;
        isTrackingKite = true;
    }

    public void SwitchToPlayerCamera()
    {
        playerCamera.Priority = 1;
        kiteCamera.Priority = 0;
    }
}

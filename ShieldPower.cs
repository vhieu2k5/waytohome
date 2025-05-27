using System.Collections;
using UnityEngine;

public class ShieldPower : MonoBehaviour
{
    public GameObject shieldVisual; 
    public bool IsShieldActive = false;

    private void Start()
    {
        if (shieldVisual != null)
            shieldVisual.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ShieldItem"))
        {
            if (shieldVisual != null)
                shieldVisual.SetActive(true);

            IsShieldActive = true;
            StartCoroutine(ShieldTimer());
            Destroy(other.gameObject);
        }

        else if (other.gameObject.layer == LayerMask.NameToLayer("ObstaclesTouch"))
        {
            if (IsShieldActive)
            {
                Destroy(other.transform.root.gameObject); 
                DeactivateShield();
            }
            else
            {
       
            }
        }
    }

    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(8f);
        if (IsShieldActive)
        {
            DeactivateShield();
        }
    }

    public void DeactivateShield()
    {
        IsShieldActive = false;
        if (shieldVisual != null)
            shieldVisual.SetActive(false);
    }
}

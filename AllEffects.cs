using System.Collections;
using UnityEngine;

public enum EffectType { SpeedBoost, PushBack }

public class Effect : MonoBehaviour
{
    public EffectType effectType;
    public float effectValue = 2f;
    public float duration = 5f;
    //private GameObject shieldVisual;

    private GameObject chaser;
    //private bool isShieldActive = false;
    private GameObject player;

    private void Start()
    {
        chaser = GameObject.FindGameObjectWithTag("Chaser");
        player = GameObject.FindGameObjectWithTag("Player");
        //shieldVisual = GameObject.FindGameObjectWithTag("ShieldVisual");

        //if (effectType == EffectType.Shield && player != null)
        //{
        //    Transform visual = player.transform.Find("ShieldVisual");
        //    if (visual != null)
        //        shieldVisual = visual.gameObject;
        //        //shieldVisual.SetActive(false);
        //}
        //if (shieldVisual != null)
        //    shieldVisual.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (effectType)
            {
                case EffectType.SpeedBoost:
                    StartCoroutine(ApplySpeedBoost());
                    break;
                case EffectType.PushBack:
                    StartCoroutine(ApplyPushBack());
                    break;
                //case EffectType.Shield:
                //    StartCoroutine(ApplyShield());
                //    break;
            }

            Destroy(gameObject);
        }
    }

    IEnumerator ApplySpeedBoost()
    {
        float originalSpeed = BackGroundLoop.scrollSpeed;
        float originalMove = ObstaclesMove.moveSpeed;

        BackGroundLoop.scrollSpeed += effectValue;
        ObstaclesMove.moveSpeed += effectValue;

        yield return new WaitForSeconds(duration);

        BackGroundLoop.scrollSpeed = originalSpeed;
        ObstaclesMove.moveSpeed = originalMove;
    }

    IEnumerator ApplyPushBack()
    {
        if (chaser != null)
        {
            Vector3 newPos = chaser.transform.position;
            newPos.x = Mathf.Max(newPos.x - effectValue, -11f);
            chaser.transform.position = newPos;

            yield return new WaitForSeconds(duration);

            newPos.x += effectValue;
            chaser.transform.position = newPos;
        }
    }

    //IEnumerator ApplyShield()
    //{
    //    if (shieldVisual != null)
    //        shieldVisual.SetActive(true);

    //    isShieldActive = true;

    //    yield return new WaitForSeconds(duration);

    //    if (isShieldActive)
    //        DeactivateShield();
    //}

    //public void DeactivateShield()
    //{
    //    isShieldActive = false;
    //    if (shieldVisual != null)
    //        shieldVisual.SetActive(false);
    //}

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (effectType == EffectType.Shield && other.gameObject.layer == LayerMask.NameToLayer("ObstaclesTouch"))
    //    {
    //        if (isShieldActive)
    //        {
    //            Destroy(other.transform.root.gameObject);
    //            DeactivateShield();
    //        }
    //    }
    //}
}


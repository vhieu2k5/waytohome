using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillBar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valueNumber;

    public KiteController Star;

    public void UpdateBar()
    {
        if (Star != null && Star.totalStars > 0)
        {
            fillBar.fillAmount = (float)Star.collectedStars / Star.totalStars;
            valueNumber.text = Star.collectedStars.ToString() + "/" + Star.totalStars.ToString();
        }
    }
}

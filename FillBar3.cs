using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillBar3 : MonoBehaviour
{
    public Image fillbar;
    public TextMeshProUGUI numberStar;

    public StarCollection star;

    public void UpdateBar()
    {
        if(star!=null)
        {
            fillbar.fillAmount = (float)star.starsCollected / star.totalStars;
            numberStar.text = star.starsCollected.ToString() + "/"
                + star.totalStars.ToString();
        }
    }
}

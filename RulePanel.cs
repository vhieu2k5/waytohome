using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidePanel : MonoBehaviour
{
    public GameObject ruleMenu;
    public Button exitSign;
    public Move CanMove;
    void Start()
    {
        ruleMenu.SetActive(false);
    }
    public void showGuide()
    {
        ruleMenu.SetActive(true);
        Time.timeScale = 0;
        CanMove.enabled = false;
    }
    public void HideGuide()
    {
        ruleMenu.SetActive(false);
        Time.timeScale = 1;
        CanMove.enabled = true;
    }
}

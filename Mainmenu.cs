using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    public GameObject go;
    public GameObject menu;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public float countdownTime = 0.1f;

    public void QuitGame()
    {
      
            go.SetActive(true);
        menu.SetActive(false);
            float timeLeft = countdownTime;

            while (timeLeft > 0)
            {
                timeLeft--; 
            }

            Application.Quit();
        
    }
}

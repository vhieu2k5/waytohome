using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    [SerializeField] private GameObject tryAgainPanel;
    [SerializeField] private VideoPlayer tryAgainVideo; 

    private bool isGameOver = false;
    private bool isTimeRed = false;

    void Start()
    {
        tryAgainPanel.SetActive(false);

        if (tryAgainVideo != null)
        {
            tryAgainVideo.loopPointReached += OnVideoEnd; 
            tryAgainVideo.Stop(); 
        }
    }

    void Update()
    {
        if (isGameOver) return;

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = 0;

            if (!isTimeRed)
            {
                timerText.color = Color.red;
                isTimeRed = true;
                Invoke("GameOver", 1f);
            }
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isGameOver = true;
        tryAgainPanel.SetActive(true); 

        if (tryAgainVideo != null)
        {
            tryAgainVideo.Play(); 
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video Try Again đã kết thúc!");
    }
}

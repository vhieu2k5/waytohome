using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollection : MonoBehaviour
{
    public FillBar3 fillbar;
    public int starsCollected = 0;
    public int totalStars = 10;
    public GameObject winPanel;


    private void Start()
    {
        winPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            starsCollected++;
            Destroy(other.gameObject);
            fillbar.UpdateBar();

            if(starsCollected == totalStars)
            {
                winPanel.SetActive(true);
                Time.timeScale = 0;
                // m có thể cho thêm time: sau khi thu thập
                // đủ 10 sao thì cho hiện cái
                // boxchat:"Aaa mình nhớ ra tất cả rồi!!"
                // hay đại đại gì đấy tầm 5s rồi cho end cũng dc :>>
            }
        }
    }
}

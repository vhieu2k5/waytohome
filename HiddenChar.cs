using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HiddenChar : MonoBehaviour
{
    public GameObject questionPanel;
    public SpriteRenderer characterSprite;
    public TMP_InputField answerInput;
    public string correctAnswer;
    public GameObject CorrectChatbox;
    public GameObject WrongChatbox;
    public bool isPlayerNearby = false;
    private void Start()
    {
        questionPanel.SetActive(false);
        CorrectChatbox.SetActive(false);
        WrongChatbox.SetActive(false);
    }

    private void Update()
    {
        if(isPlayerNearby && GetComponent<Collider2D>().enabled && Input.GetKeyDown(KeyCode.E))
        {
            questionPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    public void CheckAnswer()
    {
        if(answerInput.text.ToLower() == correctAnswer.ToLower())
        {
            CorrectChatbox.SetActive(true);
            characterSprite.sortingOrder = 10;
            questionPanel.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
            Time.timeScale = 1;
        }

        else
        {
            WrongChatbox.SetActive(true);
            answerInput.text = "";
        }
    }

    public void IgnorePanel()
    {
        questionPanel.SetActive(false);
        Time.timeScale = 1;
    }
}

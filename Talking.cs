using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Talking : MonoBehaviour
{
    public GameObject quizPanel;
    //public TMP_InputField answerInput;
    //public string correctAns;
    //public GameObject CorrectAns;
    //public GameObject WrongAns1;
    //public GameObject WrongAns2;
    public GameObject CorrectSuggestion;
    public GameObject WrongSuggestion;
    public bool isPlayerNearby = false;
    private void Start()
    {
        quizPanel.SetActive(false);
        CorrectSuggestion.SetActive(false);
        WrongSuggestion.SetActive(false);
    }

    private void Update()
    {
       if(isPlayerNearby && GetComponent<Collider2D>().enabled && Input.GetKeyDown(KeyCode.E))
        {
            quizPanel.SetActive(true);
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

    public void Correct()
    {
        //if(answerInput.text.Trim().ToLower() == correctAns.Trim().ToLower())
        CorrectSuggestion.SetActive(true);
        quizPanel.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
        Time.timeScale = 1;
    }

            
    public void Wrong()
    {
            WrongSuggestion.SetActive(true);
            quizPanel.SetActive(false);
            Time.timeScale = 1;
            GetComponent<Collider2D>().enabled = false;
    }

    public void IgnorePanel()
    {
        quizPanel.SetActive(false);
        Time.timeScale = 1;
    }
}

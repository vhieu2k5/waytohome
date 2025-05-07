using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrushChat : MonoBehaviour
{
    [System.Serializable]
    public class DialogueTurn
    {
        public string crushLine;
        public string option1;
        public string option2;
        public string option3;

        public string response1;
        public string response2;
        public string response3;

        public int point1;
        public int point2;
        public int point3;
    }

    public List<DialogueTurn> dialogueTurns;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject CompletePanel;
    public GameObject LosePanel;

    public Button option1Button;
    public Button option2Button;
    public Button option3Button;
    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;
    public TextMeshProUGUI option3Text;

    public TextMeshProUGUI LoveScore;

    private int index = 0;

    private bool isChoosing = false;

    private int Points = 0;

    public float wordSpeed;
    public bool playerIsClose = false;
    void Start()
    {
        dialoguePanel.SetActive(false);
        CompletePanel.SetActive(false);
        LosePanel.SetActive(false);

        option1Button.onClick.AddListener(() => PlayerChoose(1));
        option2Button.onClick.AddListener(() => PlayerChoose(2));
        option3Button.onClick.AddListener(() => PlayerChoose(3));

        if (LoveScore != null) LoveScore.text = "";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                ShowCrushLine();
            }
        }
    }
    void ShowCrushLine()
    {
        if (index < dialogueTurns.Count)
        {
            DialogueTurn turn = dialogueTurns[index];
            dialogueText.text = "Crush:";
            StartCoroutine(TypeLineThenShowOptions(turn));
        }
        else
        {
            StartCoroutine(ShowCompletePanelWithPoints());
        }
    }
    IEnumerator TypeLineThenShowOptions(DialogueTurn turn)
    {
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);
        option3Button.gameObject.SetActive(false);

        foreach (char letter in turn.crushLine.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        option1Text.text = turn.option1;
        option2Text.text = turn.option2;
        option3Text.text = turn.option3;

        option1Button.gameObject.SetActive(true);
        option2Button.gameObject.SetActive(true);
        option3Button.gameObject.SetActive(true);

        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;

        isChoosing = true;
    }
    IEnumerator TypeText(string line)
    {
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    void PlayerChoose(int optionNumber)
    {
        DialogueTurn turn = dialogueTurns[index];

        string playerChoice = "";
        string crushResponse = "";
        int points = 0;

        if (optionNumber == 1)
        {
            playerChoice = turn.option1;
            crushResponse = turn.response1;
            points = turn.point1;
        }

        else if (optionNumber == 2)
        {
            playerChoice = turn.option2;
            crushResponse = turn.response2;
            points = turn.point2;
        }
        else if (optionNumber == 3)
        {
            playerChoice = turn.option3;
            crushResponse = turn.response3;
            points = turn.point3;
        }

        // Hiện người chơi trả lời và crush phản hồi
        StopAllCoroutines();
        dialogueText.text = "";
        StartCoroutine(TypeText("Crush: " + crushResponse));

        Points += points;

        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);
        option3Button.gameObject.SetActive(false);
        index++;
        isChoosing = false;
        StartCoroutine(NextTurnAfterDelay());
    }

    IEnumerator NextTurnAfterDelay()
    {
        yield return new WaitForSeconds(4.5f);
        if (index < dialogueTurns.Count)
        {
            ShowCrushLine();
        }
        else
        {
            StartCoroutine(ShowCompletePanelWithPoints());
        }
        
}

    IEnumerator ShowCompletePanelWithPoints()
    {
        yield return new WaitForSeconds(1f);
        ScoreAppear();

        yield return new WaitForSeconds(0.1f);

        if (Points >= 55)
            {
                
                CompletePanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                
                LosePanel.SetActive(true);
                Time.timeScale = 0;
            }
       
    }

    void ScoreAppear()
    {
        if(LoveScore != null)
        {
            LoveScore.text = "Điểm cảm tình của crush:" + Points.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            dialoguePanel.SetActive(false);
        }
    }

    IEnumerator ShowDialogue(string dialogue)
    {
        dialogueText.text = "";
        dialogueText.text = dialogue;
        yield return new WaitForSeconds(5f);
    }
}
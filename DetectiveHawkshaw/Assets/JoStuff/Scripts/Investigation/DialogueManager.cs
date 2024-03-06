using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    

    public bool puzzleDialogue;
    public bool sandwichDialogue;
    public bool calendarDialogue;
    public bool otherPuzzleDialogue; //this is just for testing purposes rn & once the tut puzzle is replaced with a pop-up it'll just use the first puzzle bool
    
    public bool evidenceDialogue;
    public GameObject evidenceWindow;
    public Image evidenceSprite;
    //public GameObject evidence1;
    //public GameObject evidence2;

    public Queue<string> sentences;
    private InterrogationCheck interrogationCheck;

    public bool allEvidence;

    public GameObject toInterrogation;

    public Evidence evidenceStats;

    public GameObject testObject;


    // Use this for initialization
    private void Start()
    {
        puzzleDialogue = false;
        sentences = new Queue<string>();
        
        //preparing dialogue placements
        dialogueBox = GameObject.FindWithTag("DialogueBox");
        nameText = dialogueBox.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        dialogueText = dialogueBox.transform.Find("Dialogue").GetComponent<TextMeshProUGUI>();
        dialogueBox.SetActive(false);
        
        //evidence pop-up stuff
        evidenceWindow = GameObject.FindWithTag("EvidencePortrait");
        evidenceSprite = evidenceWindow.transform.Find("Evidence").GetComponent<Image>();
        evidenceWindow.SetActive(false);
        
        //interrogation button stuff
        interrogationCheck = FindObjectOfType<InterrogationCheck>();
        toInterrogation = GameObject.FindWithTag("InterrogationButton");

        if (!allEvidence)
        {
            toInterrogation.GetComponent<Button>().interactable = false;
        }
        
        evidenceStats = null;
        allEvidence = false;

        /*
        if (sandwichDialogue)
        {
            sandwichWindow = GameObject.Find("SandwichPortrait");
            sandwichWindow.SetActive(false);
        }

        else
        {
            sandwichWindow = null;
        }
        */
    }

    private void Update()
    {
        if (PauseGame.isPaused) return;
        if (!dialogueBox.activeInHierarchy) return;

        if (Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        
        dialogueBox.SetActive(true);
        
        nameText.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if (evidenceDialogue)
        {
            evidenceWindow.SetActive(true);
            evidenceSprite.sprite = evidenceStats.evidencePic;
        }

    }

    private void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (sandwichDialogue && sentences.Count == 3)
        {
            //sandwichWindow.SetActive(true);
            evidenceSprite.sprite = evidenceStats.evidencePic;
            evidenceWindow.SetActive(true);
        }

        if (calendarDialogue && sentences.Count == 2)
        {
            //evidence1.SetActive(false);
            evidenceSprite.sprite = evidenceStats.evidencePic2;
            //evidence2.SetActive(true);
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        sentences.Clear();
        dialogueBox.SetActive(false);

        if (puzzleDialogue)
        {
            FindObjectOfType<PuzzleTrigger>().LoadPuzzleScene();
            puzzleDialogue = false;
        }

        else if (evidenceDialogue || sandwichDialogue)
        {
            if (calendarDialogue)
            {
                //evidence1.SetActive(true);
                //evidence2.SetActive(false);
                calendarDialogue = false;
            }

            evidenceWindow.SetActive(false);
            evidenceDialogue = false;

            if (toInterrogation.GetComponent<Button>().interactable == false)
            {
                EvidenceCheck();
            }
        }
        
        else if (otherPuzzleDialogue)
        {
            var g = FindObjectOfType<OtherPuzzleTrigger>();
            g.puzzleScreen.SetActive(true);
            otherPuzzleDialogue = false;
        }

    }


    private void EvidenceCheck()
    {
        if (allEvidence)
        {
            toInterrogation.GetComponent<Button>().interactable = true;
            toInterrogation.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Interrogation";
        }

        else
        {
            interrogationCheck.CheckEvidence();
        }

    }
}

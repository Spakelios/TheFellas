using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;

    public bool puzzleDialogue;
    public bool sandwichDialogue;
    public bool calendarDialogue;

    
    public bool evidenceDialogue;
    public GameObject evidenceWindow;
    public GameObject evidence1;
    public GameObject evidence2;

    public Queue<string> sentences;
    private InterrogationCheck interrogationCheck;
    
    

    // Use this for initialization
    private void Start()
    {
        puzzleDialogue = false;
        sentences = new Queue<string>();
        evidenceWindow = GameObject.FindWithTag("EvidencePortrait");
        evidenceWindow.SetActive(false);
        interrogationCheck = FindObjectOfType<InterrogationCheck>();

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
        dialogueBox.SetActive(true);
        
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if (evidenceDialogue)
        {
            evidenceWindow.SetActive(true);
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
            evidenceWindow.SetActive(true);
        }

        if (calendarDialogue && sentences.Count == 2)
        {
            evidence1.SetActive(false);
            evidence2.SetActive(true);
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
        dialogueBox.SetActive(false);

        if (puzzleDialogue)
        {
            FindObjectOfType<PuzzleTrigger>().LoadPuzzleScene();
        }

        else if (evidenceDialogue || sandwichDialogue)
        {
            if (calendarDialogue)
            {
                evidence1.SetActive(true);
                evidence2.SetActive(false);
                calendarDialogue = false;
            }
            
            evidenceWindow.SetActive(false);
            evidenceDialogue = false;
        }
        
        interrogationCheck.CheckEvidence();
    }
}

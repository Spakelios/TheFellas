using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    

    public Queue<string> sentences;

    // Use this for initialization
    private void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
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

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
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

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}

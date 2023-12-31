using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvestigationDialogueTrigger : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    public TextMeshProUGUI examineTagBox;

    public static List<int> isExamined = new List<int>();
    public string examineTag;
    public string newExamineTag;
    public int referenceID;

    public bool evidence;
    public bool calendar;

    public AudioSource evidenceSound;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        examineTagBox.text = "";
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (eyeSpawned)
        {
            eye.transform.position = mousePos;
        }
    }
    
    private void OnMouseEnter()
    {
        if (dialogueManager.dialogueBox.activeInHierarchy) return;

        if (isExamined.Contains(referenceID))
        {
            examineTag = newExamineTag;
        }
        
        examineTagBox.text = examineTag;
    }
    
    public void OnMouseOver()
    {
        if (dialogueManager.dialogueBox.activeInHierarchy) return;
        
        if (!eyeSpawned)
        {
            Cursor.visible = false;
            eye = Instantiate(eyePrefab);
            eyeSpawned = true;
        }

        if (!Input.GetMouseButtonDown(0)) return;
        OnMouseExit();

        if (evidence)
        {
            evidenceSound.Play();
            dialogueManager.evidenceDialogue = true;
        }

        if (calendar)
        {
            evidenceSound.Play();
            dialogueManager.calendarDialogue = true;
        }

        if (dialogueManager.sandwichDialogue)
        {
            evidenceSound.Play();
        }

        dialogueManager.StartDialogue(dialogue);

        if (!isExamined.Contains(referenceID))
        {
            isExamined.Add(referenceID);
        }
    }
    
    private void OnMouseExit()
    {
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;
        examineTagBox.text = "";
    }
}
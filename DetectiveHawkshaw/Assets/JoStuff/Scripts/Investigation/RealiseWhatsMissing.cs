using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class RealiseWhatsMissing : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    private static int plus = 0;
    public InitialisationScript initialiser;

    public Evidence evidenceStats;

    public TextAsset notAllFound;
    public TextAsset allFound;
    public TextAsset missingCase;
    
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;
    
    public TextMeshProUGUI examineTagBox;
    public string examineTag;
    public string newExamineTag;
    
    private Collider2D collider;
    private Camera camera;
    
    [SerializeField] private Vector3 textOffset;

    private void Start()
    {
        camera = Camera.main;
        initialiser = FindObjectOfType<InitialisationScript>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        textOffset = new Vector3(0, 30, 0);
        examineTagBox = GameObject.FindWithTag("ExamineTag").GetComponent<TextMeshProUGUI>();
        examineTagBox.text = "";

        if (InvestigationDialogueTrigger.isExamined.Count != initialiser.caseData.caseEvidence.Count - 1)
        {
            var d = notAllFound.text.Split("\n");
            var di = d.ToList();
            dialogue.sentences = di;
            GetComponent<BoxCollider2D>().enabled = false;
        }

        else
        {
            var d = allFound.text.Split("\n");
            var di = d.ToList();
            dialogue.sentences = di;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        
        dialogueManager.StartDialogue(dialogue);
    }

    private void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        examineTagBox.transform.position = Input.mousePosition + textOffset;

        if (eyeSpawned)
        {
            eye.transform.position = mousePos;
        }
    }
    
    private void OnMouseEnter()
    {
        if (PauseGame.isPaused) return;
        if (dialogueManager.dialogueBox.activeInHierarchy) return;
    }

    private void OnMouseOver()
    {
        if (PauseGame.isPaused) return;
        if (dialogueManager.dialogueBox.activeInHierarchy) return;
        
        if (!eyeSpawned)
        {
            Cursor.visible = false;
            eye = Instantiate(eyePrefab);
            eyeSpawned = true;
        }
        
        if (InvestigationDialogueTrigger.isExamined.Contains(evidenceStats))
        {
            examineTag = newExamineTag;
        }
        
        examineTagBox.text = examineTag;
        examineTagBox.color = Color.black;
        
        if (!Input.GetMouseButtonDown(0)) return;
        OnMouseExit();
        
        dialogueManager.evidenceDialogue = true;
        InvestigationDialogueTrigger.isExamined.Add(evidenceStats);
        
        var d = missingCase.text.Split("\n");
        var di = d.ToList();
        dialogue.sentences = di;
        
        dialogueManager.evidenceStats = evidenceStats;
        dialogueManager.StartDialogue(dialogue);
    }

    private void OnMouseExit()
    {
        if (PauseGame.isPaused) return;
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;
        examineTagBox.text = "";
    }
}

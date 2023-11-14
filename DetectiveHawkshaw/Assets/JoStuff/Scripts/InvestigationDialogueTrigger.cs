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
    public string examineTag;
    


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
        
        Cursor.visible = false;
        eye = Instantiate(eyePrefab);
        eyeSpawned = true;
        examineTagBox.text = examineTag;
    }
    
    public void OnMouseOver()
    {
        if (dialogueManager.dialogueBox.activeInHierarchy) return;
        
        if (!Input.GetMouseButtonDown(0)) return;
        OnMouseExit();
        dialogueManager.StartDialogue(dialogue);
        examineTagBox.text = "";
        
    }
    
    private void OnMouseExit()
    {
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;
        examineTagBox.text = "";
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Ink.Parsed;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


//USE THIS IF PEOPLE'S DIALOGUE IN THE INVESTIGATION SCENE ISN'T GONNA COUNT AS EVIDENCE
//COULD ALSO PROBABLY BE USED AS NON-EVIDENCE DIALOGUE
public class PeopleInvestigationDialogueTrigger : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    //public GameObject examineContainer;
    public TextMeshProUGUI examineTagBox;
    
    public string examineTag;

    private Collider2D collider;
    
    private Camera camera;
    
    //public AudioSource evidenceSound;
    
    
    private void Start()
    {
        camera = Camera.main;
        dialogueManager = FindObjectOfType<DialogueManager>();
        examineTagBox.text = "";
    }

    private void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        if (eyeSpawned)
        {
            eye.transform.position = mousePos;
        }
    }
    
    private void OnMouseEnter()
    {
        if (PauseGame.isPaused) return;
        if (dialogueManager.dialogueBox.activeInHierarchy) return;
        examineTagBox.text = examineTag;
    }

    public void OnMouseOver()
    {
        if (PauseGame.isPaused) return;
        if (dialogueManager.dialogueBox.activeInHierarchy) return;

        if (!eyeSpawned)
        {
            Cursor.visible = false;
            eye = Instantiate(eyePrefab);
            eyeSpawned = true;
        }

        if (!Input.GetMouseButtonDown(0)) return;
        OnMouseExit();

        FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.evidence, transform.position);

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

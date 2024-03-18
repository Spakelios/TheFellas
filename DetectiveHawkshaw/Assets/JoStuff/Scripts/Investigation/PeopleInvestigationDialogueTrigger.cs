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

    private Vector3 textOffset;

    public Animator animation;
    
    public GameObject puzzle;
    
    
    //public AudioSource evidenceSound;
    
    
    private void Start()
    {
        camera = Camera.main;
        dialogueManager = FindObjectOfType<DialogueManager>();
        textOffset = new Vector3(0, 30, 0);
        examineTagBox = GameObject.FindWithTag("ExamineTag").GetComponent<TextMeshProUGUI>();
        examineTagBox.text = "";
        
        /*
        Cursor.visible = false;
        if (!eyeSpawned)
        {
            eye = Instantiate(eyePrefab);
        }
        animation = eye.transform.GetComponentInChildren<Animator>();
        animation.speed = 0f;
        */


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
        if (puzzle != null && puzzle.activeInHierarchy) return;
    }

    public void OnMouseOver()
    {
        if (PauseGame.isPaused) return;
        if (dialogueManager.dialogueBox.activeInHierarchy) return;
        if (puzzle != null && puzzle.activeInHierarchy) return;

        
        if (!eyeSpawned)
        {
            Cursor.visible = false;
            eye = Instantiate(eyePrefab);
            eyeSpawned = true;
        }
        

        //animation.speed = 1f;
        
        examineTagBox.text = examineTag;
        examineTagBox.color = Color.white;

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
        
        //animation.speed = 0f;
        examineTagBox.text = "";
    }




}

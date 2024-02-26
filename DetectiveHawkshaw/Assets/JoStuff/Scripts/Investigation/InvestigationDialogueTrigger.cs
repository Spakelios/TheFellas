using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Ink.Parsed;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


//NOTE: USE THIS SCRIPT ON PEOPLE YOU CAN TALK TO IN THE CASE IF WHAT THEY SAY WILL COUNT AS EVIDENCE
public class InvestigationDialogueTrigger : MonoBehaviour
{
    
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    public GameObject examineContainer;
    public TextMeshProUGUI examineTagBox;

    public static readonly List<int> isExamined = new List<int>();
    public string examineTag;
    public string newExamineTag;
    public int referenceID;

    public bool evidence;
    public bool calendar;

    public bool wasChecked;
    private static int plus = 0;

    private Collider2D collider;
    private Camera camera;

    [SerializeField] private Vector3 textOffset;

    //public AudioSource evidenceSound;

    public Evidence evidenceStats;

    private void Start()
    {
        camera = Camera.main;
        dialogueManager = FindObjectOfType<DialogueManager>();
        textOffset = new Vector3(0, 30, 0);
        examineTagBox = GameObject.FindWithTag("ExamineTag").GetComponent<TextMeshProUGUI>();
        examineTagBox.text = "";
        referenceID = evidenceStats.evidenceIDNumber;
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

    // public void LoadData(GameData data)
    // {
    //     data.IsExamined.TryGetValue(referenceID, out evidence);  
    //     data.IsExamined.TryGetValue(referenceID, out calendar);
    // }
    //
    // public void SaveData(GameData data)
    // {
    //     if (data.IsExamined.ContainsKey(referenceID))
    //     {
    //         if (data.IsExamined.ContainsKey(referenceID))
    //         {
    //             Debug.Log("balls");
    //         }
    //     }
    //     
    //     data.IsExamined.Add(referenceID, evidence);  
    //     data.IsExamined.Add(referenceID, calendar);

    // }

    private void OnMouseEnter()
    {
        if (PauseGame.isPaused) return;
        if (dialogueManager.dialogueBox.activeInHierarchy) return;
        
        
        //examineContainer.SetActive(true);
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
        
        if (isExamined.Contains(referenceID))
        {
            examineTag = newExamineTag;
        }
        
        examineTagBox.text = examineTag;
        examineTagBox.color = Color.black;

        if (!Input.GetMouseButtonDown(0)) return;
        OnMouseExit();

        if (evidence)
        {
            //evidenceSound.Play();
            FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.evidence, transform.position);
            dialogueManager.evidenceDialogue = true;

            if (!wasChecked)
            {
                plus++;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Intensity", plus);
                wasChecked = true;
            }
        }

        if (calendar)
        {
            //evidenceSound.Play();
            dialogueManager.calendarDialogue = true;
            
            if (!wasChecked)
            {
                plus++;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Intensity", plus);
                wasChecked = true;
            }
        }

        if (dialogueManager.sandwichDialogue)
        {
            //evidenceSound.Play();
            
            if (!wasChecked)
            {
                plus++;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Intensity", plus);
                wasChecked = true;
            }
        }
        
        if (!isExamined.Contains(referenceID))
        {
            isExamined.Add(referenceID);
        }

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
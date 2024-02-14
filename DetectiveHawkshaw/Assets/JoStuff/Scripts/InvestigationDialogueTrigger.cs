using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Ink.Parsed;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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

    public bool wasChecked;
    private static int plus = 0;

    private Collider2D collider;

    //public AudioSource evidenceSound;

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

        if (isExamined.Contains(referenceID))
        {
            examineTag = newExamineTag;
        }
        
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

        if (evidence)
        {
            //evidenceSound.Play();
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

        dialogueManager.StartDialogue(dialogue);

        if (!isExamined.Contains(referenceID))
        {
            isExamined.Add(referenceID);
        }
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
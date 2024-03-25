using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ToInterrogationChOne : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;
    public Dialogue dialogue;
    public DialogueManager dm;
    public string sceneName;

    public TextMeshProUGUI examineTagBox;

    private Camera camera;

    private Vector3 textOffset;

    public GameObject puzzle;

    public TextAsset notAllEvidenceFile;
    public TextAsset allEvidenceFile;
    private InitialisationScript initialiser;
    public string hoverTag;
    
    private void Start()
    {
        camera = Camera.main;
        textOffset = new Vector3(0, 30, 0);
        examineTagBox = GameObject.FindWithTag("ExamineTag").GetComponent<TextMeshProUGUI>();
        examineTagBox.text = "";
        dm = FindObjectOfType<DialogueManager>();
        examineTagBox.text = "";
        initialiser = FindObjectOfType<InitialisationScript>();
        sceneName = initialiser.caseData.interrogationSceneName;
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

    public void OnMouseEnter()
    {
        if (PauseGame.isPaused) return;
        if (dm.dialogueBox.activeInHierarchy) return;
        if (puzzle != null && puzzle.activeInHierarchy) return;

        FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.doorKnock, transform.position);
    }

    public void OnMouseOver()
    {
        if (PauseGame.isPaused) return;
        if (dm.dialogueBox.activeInHierarchy) return;
        if (puzzle != null && puzzle.activeInHierarchy) return;

        if (!eyeSpawned)
        {
            Cursor.visible = false;
            eye = Instantiate(eyePrefab);
            eyeSpawned = true;
        }

        examineTagBox.text = hoverTag;
        examineTagBox.color = Color.white;
        
        if (!Input.GetMouseButtonDown(0)) return;
        OnMouseExit();
        
        if (dm.allEvidence != true)
        {
            var d = notAllEvidenceFile.text.Split("\n");
            var di = d.ToList();
        
            dialogue.sentences = di;
            dm.StartDialogue(dialogue);
        }

        else
        {
            var d = allEvidenceFile.text.Split("\n");
            var di = d.ToList();
        
            dialogue.sentences = di;
            dm.interroCh1 = true;
            dm.StartDialogue(dialogue);
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

    public void ToInterrogation()
    {
        RoomLoader.instance.LoadLevel(sceneName);
    }
}

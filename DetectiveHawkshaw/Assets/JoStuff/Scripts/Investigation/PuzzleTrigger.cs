using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PuzzleTrigger : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    public string sceneName;
    
    public TextMeshProUGUI examineTagBox;

    public static bool puzzleSolved;

    private Camera camera;
    
    private Vector3 textOffset;
    //public AudioSource doorKnock;
    //private AudioSource doorOpen;

    private void Start()
    {
        camera = Camera.main;
        textOffset = new Vector3(0, 30, 0);
        examineTagBox = GameObject.FindWithTag("ExamineTag").GetComponent<TextMeshProUGUI>();
        examineTagBox.text = "";
        dialogueManager = FindObjectOfType<DialogueManager>();
        examineTagBox.text = "";
        //doorOpen = GameObject.Find("Open Door").GetComponent<AudioSource>();
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

        FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.doorKnock, transform.position);
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

        examineTagBox.text = sceneName;
        examineTagBox.color = Color.white;
        
        if (!Input.GetMouseButtonDown(0)) return;
        OnMouseExit();

        if (puzzleSolved)
        {
            //doorOpen.Play();
            //SceneManager.LoadScene(sceneName);
            RoomLoader.instance.LoadLevel(sceneName);
        }

        else
        {
            dialogueManager.puzzleDialogue = true;
            dialogueManager.StartDialogue(dialogue);
        }
    }

    public void OnMouseExit()
    {
        if (PauseGame.isPaused) return;
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;
        examineTagBox.text = "";
    }

    public void LoadPuzzleScene()
    {
        SceneManager.LoadScene("NumberLockPuzzle");
    }
    
}

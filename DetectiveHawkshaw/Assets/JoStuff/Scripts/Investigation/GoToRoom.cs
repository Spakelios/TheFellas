using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoToRoom : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;

    public GameObject dialogueBox;
    public string sceneName;
    
    public TextMeshProUGUI examineTagBox;
    
    private Vector3 textOffset;
    
    private Camera camera;

    public DialogueManager dm;
    
    //public AudioSource doorOpen;

    //public AudioSource doorKnock;





    // Update is called once per frame

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        //dialogueBox = GameObject.FindWithTag("DialogueBox");
        //dialogueBox = dm.dialogueBox.gameObject;
        examineTagBox = GameObject.FindWithTag("ExamineTag").GetComponent<TextMeshProUGUI>();
        examineTagBox.text = "";
        camera = Camera.main;
        textOffset = new Vector3(0, 30, 0);
        //doorOpen = GameObject.Find("Open Door").GetComponent<AudioSource>();
        JournalInitialiser.journal.SetActive(true);
        OnMouseExit();


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
        if (dm.dialogueBox.activeInHierarchy) return;
        
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
        //doorOpen.Play();
        //SceneManager.LoadScene(sceneName);
        JournalInitialiser.journal.SetActive(false);
        RoomLoader.instance.LoadLevel(sceneName);
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

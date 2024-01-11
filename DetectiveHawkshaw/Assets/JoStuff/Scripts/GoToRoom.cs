using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using FMOD;

public class GoToRoom : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;

    public GameObject dialogueBox;
    public string sceneName;
    
    public TextMeshProUGUI examineTagBox;
    //public AudioSource doorOpen;

    //public AudioSource doorKnock;

    // Update is called once per frame

    private void Start()
    {
        examineTagBox.text = "";
        //doorOpen = GameObject.Find("Open Door").GetComponent<AudioSource>();
        OnMouseExit();

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
        //doorKnock.Play();
    }

    public void OnMouseOver()
    {
        if (dialogueBox.activeInHierarchy) return;
        
        if (!eyeSpawned)
        {
            Cursor.visible = false;
            eye = Instantiate(eyePrefab);
            eyeSpawned = true;
        }

        examineTagBox.text = sceneName;
        
        if (!Input.GetMouseButtonDown(0)) return;
        OnMouseExit();
        //doorOpen.Play();
        //SceneManager.LoadScene(sceneName);
        RoomLoader.instance.LoadLevel(sceneName);
    }
    
    
    
    private void OnMouseExit()
    {
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;

        examineTagBox.text = "";
    }
}

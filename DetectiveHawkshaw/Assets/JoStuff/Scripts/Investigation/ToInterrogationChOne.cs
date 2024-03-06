using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToInterrogationChOne : MonoBehaviour
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

    private void Start()
    {
        camera = Camera.main;
        textOffset = new Vector3(0, 30, 0);
        examineTagBox = GameObject.FindWithTag("ExamineTag").GetComponent<TextMeshProUGUI>();
        examineTagBox.text = "";
        dialogueManager = FindObjectOfType<DialogueManager>();
        examineTagBox.text = "";
    }
}

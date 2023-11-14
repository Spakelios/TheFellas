using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToRoom : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;

    public GameObject dialogueBox;
    public string sceneName;

    // Update is called once per frame

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
        if(dialogueBox.activeInHierarchy) return;
        
        Cursor.visible = false;
        eye = Instantiate(eyePrefab);
        eyeSpawned = true;
    }

    public void OnMouseOver()
    {
        if (dialogueBox.activeInHierarchy) return;
        
        if (!Input.GetMouseButtonDown(0)) return;
        OnMouseExit();
        SceneManager.LoadScene(sceneName);
    }
    
    
    
    private void OnMouseExit()
    {
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;
    }
}

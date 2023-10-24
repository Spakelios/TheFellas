using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OpenSheet : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;
    public GameObject panel;
    public GameObject sheet;
    public GameObject keypad;
    public GameObject safeDoor;
    private Keypad keypadScript;

    private void Start()
    {
        keypadScript = FindObjectOfType<Keypad>();
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
        if (panel.activeInHierarchy) return;
        
        Cursor.visible = false;
        eye = Instantiate(eyePrefab);
        eyeSpawned = true;
    }

    private void OnMouseOver()
    {
        if (panel.activeInHierarchy) return;
        
        if (!Input.GetMouseButtonDown(0)) return;
        
        OnMouseExit();

        if (gameObject.CompareTag("Sheet"))
        {
            panel.SetActive(true);
            sheet.SetActive(true);
        }
            
        else if (gameObject.CompareTag("Keypad"))
        {
            panel.SetActive(true);
            keypad.SetActive(true);
        }
        
        else if (gameObject.CompareTag("Knob") && keypadScript.keyGot)
        {
            safeDoor.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;
        
    }
}

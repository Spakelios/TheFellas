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
        panel.SetActive(true);

        if (gameObject.CompareTag("Sheet"))
        {
            sheet.SetActive(true);
        }
            
        else if (gameObject.CompareTag("Keypad"))
        {
            keypad.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;
        
    }
}

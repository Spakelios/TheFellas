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
        Cursor.visible = false;
        eye = Instantiate(eyePrefab);
        eyeSpawned = true;
        Debug.Log("Mouse on");
    }

    private void OnMouseExit()
    {
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;
        Debug.Log("Mouse off");
    }
}

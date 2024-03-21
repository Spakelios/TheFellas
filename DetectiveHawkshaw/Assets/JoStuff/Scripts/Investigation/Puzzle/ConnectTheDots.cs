using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectTheDots : MonoBehaviour
{
    public LineRenderer rope;
    public GameObject pin;
    private GameObject startPin;
    private GameObject endPin;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Camera camera;
    private Vector2 mousePos;
    private DotsTracker dots;

    public GameObject explanation;

    private void Start()
    {
        camera = Camera.main;
        dots = FindObjectOfType<DotsTracker>();
        
        rope.startWidth = 0.1f;
        rope.endWidth = 0.1f;
        
        
    }

    private void OnMouseOver()
    {
        if (PauseGame.isPaused) return;
        if (explanation.activeInHierarchy) return;
        
        if (!Input.GetMouseButtonDown(0)) return;
        if (startPin != null) return;
        startPin = Instantiate(pin);
        FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.lockScroll, transform.position);
        startPin.transform.position = mousePos;
        startPin.tag = tag;
        startPoint = startPin.transform.position;
        
        rope.SetPosition(0, startPoint);
    }
    
    private void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        
        if(startPin == null || endPin != null) return;

        endPoint = mousePos;
        
        rope.SetPosition(1, endPoint);
        
        if (!Input.GetMouseButtonDown(1)) return;

        endPin = Instantiate(pin);
        FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.lockScroll, transform.position);
        endPin.transform.position = mousePos;
        endPoint = endPin.transform.position;
        rope.SetPosition(1, endPoint);
        CheckPin();
        

    }

    private void CheckPin()
    {
        var hit = Physics2D.Raycast(endPoint, Vector2.zero);
        
        if(hit)
        {
            endPin.tag = hit.transform.tag;

            if (startPin.tag == endPin.tag)
            {
                dots.score++;
                dots.CheckScore();
            }

            else
            {
                Destroy(startPin);
                Destroy(endPin);
                rope.SetPosition(0, new Vector3(0, 0, 0));
                rope.SetPosition(1, new Vector3(0, 0, 0));
            }
        }

        else
        {
            Destroy(startPin);
            Destroy(endPin);
            rope.SetPosition(0, new Vector3(0, 0, 0));
            rope.SetPosition(1, new Vector3(0, 0, 0));
            
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Sprite crumbs,toilet,cucumber,calender,Katya,Nicolai;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (name == "woah5")
        {
            gameObject.GetComponentInChildren<Image>().sprite = crumbs;
        }
        if (name == "woah4")
        {
            gameObject.GetComponentInChildren<Image>().sprite = cucumber;
        }    
        if (name == "woah3")
        {
            gameObject.GetComponentInChildren<Image>().sprite = calender;
        }    
        if (name == "woah6")
        {
            gameObject.GetComponentInChildren<Image>().sprite = toilet;
        }
        if (name == "woah7")
        {
            gameObject.GetComponentInChildren<Image>().sprite = calender;
        } 
        if (name == "woah0")
        {
            gameObject.GetComponentInChildren<Image>().sprite = Nicolai;
        }
        if (name == "woah1")
        {
            gameObject.GetComponentInChildren<Image>().sprite = Katya;
        }    
    }
}

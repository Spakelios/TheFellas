using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public string correctKey;
    public string currentKey;
    public TextMeshProUGUI text;
    private bool keyGot;

    private void Start()
    {
        currentKey = "";
    }

    public void NumberEntered(int number)
    {
        if (currentKey.Length < correctKey.Length)
        {
            currentKey += number.ToString();
        }
    }

    private void Update()
    {
        text.text = currentKey;

        if (keyGot)
        {
            text.text = "CORRECT!";
        }
    }

    public void CheckNumber()
    {
        if (currentKey != correctKey)
        {
            currentKey = "";
        }

        else
        {
            keyGot = true;
        }
    }
}

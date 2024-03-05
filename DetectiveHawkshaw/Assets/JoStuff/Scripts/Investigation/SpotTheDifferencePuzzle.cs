using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpotTheDifferencePuzzle : MonoBehaviour
{
    public List<int> differences;
    public TextMeshProUGUI text;
    public static int found = 0;
    public TextMeshProUGUI total;
    public bool cloak;
    public List<TextMeshProUGUI> cloakText;

    private void Start()
    {
        differences = new List<int>
        {
            1, 2, 3
        };
        print(found);
    }

    private void OnMouseOver()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (found >= 3) return;

        if (cloak)
        {
            if (cloakText[0].text != String.Empty || cloakText[1].text != String.Empty ||
                cloakText[2].text != String.Empty) return;
            found++;
            
            foreach (var t in cloakText)
            {
                t.text = found.ToString();
            }
        }

        else
        {
            if (text.text != String.Empty) return;
            found++;
            text.text = found.ToString();
        }
    }

    private void Update()
    {
        total.text = "Differences: " + found + "/3";
    }
}

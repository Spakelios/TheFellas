using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private CanvasGroup UI;
    [SerializeField] private bool Fadeout = false;
    public GameObject canvas;

    public void HideUI()
    {
        Fadeout = true;
    }

    private void Update()
    {
        if (canvas.activeInHierarchy)
        {
            Fadeout = true;
        }

        if (Fadeout)
        {
            if (UI.alpha >= 0)

            {
                UI.alpha -= Time.deltaTime;
                if (UI.alpha == 0)
                {
                    Fadeout = false;
                }
            }
        }
    }
}

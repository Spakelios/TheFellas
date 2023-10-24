using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{

    public GameObject sheet;
    public GameObject panel;
    public GameObject keypad;

    public void Close()
    {
        keypad.SetActive(false);
        sheet.SetActive(false);
        panel.SetActive(false);
    }
}

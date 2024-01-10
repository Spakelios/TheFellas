using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Numbers : MonoBehaviour
{
    private NumberLock numberLock;
    public TextMeshProUGUI number;

    public Image dial;
    private int index;
    public Button button;
    public int currentNumber;
    public List<int> possibleNumbers;
    public int passwordDigit;

    public List<Sprite> pictures;
    //public AudioSource numberClick;
    
    private void Start()
    {
        button = GetComponent<Button>();
        dial = GetComponent<Image>();
        numberLock = FindObjectOfType<NumberLock>();
        
        index = 0;
        
        possibleNumbers = new List<int>(10)
        {
            0, 1 , 2, 3, 4, 5, 6, 7, 8, 9
        };

        currentNumber = possibleNumbers[0];
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    private void Update()
    {
        //number.text = currentNumber.ToString();
        dial.sprite = pictures[index];

    }

    private void TaskOnClick()
    {
        if (currentNumber <= possibleNumbers.Count - 2)
        {
            index++;
            currentNumber = possibleNumbers[index];
        }

        else
        {
            index = 0;
            currentNumber = possibleNumbers[0];
            
        }
        
        //numberClick.Play();
        numberLock.currentCombo.RemoveAt(passwordDigit);
        numberLock.currentCombo.Insert(passwordDigit, currentNumber);
        numberLock.CheckCombo();

    }

    public void Disable()
    {
        button.interactable = false;
    }
}

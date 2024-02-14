using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class NumberLock : MonoBehaviour
{
    public List<int> currentCombo;
    public List<int> correctCombo;
    public GameObject locked;
    public GameObject unlocked;
    public Object[] numbers;

    //public AudioSource unlockLock;

    private void Start()
    {
        currentCombo = new List<int>
        {
            0, 0, 0, 0
        };
        
        locked.SetActive(true);
        unlocked.SetActive(false);

        numbers = FindObjectsOfTypeAll(typeof(Numbers));
    }


    public void CheckCombo()
    {
        if (!currentCombo.SequenceEqual(correctCombo)) return;
        
        //unlockLock.Play();
        locked.SetActive(false);
        unlocked.SetActive(true);
        PuzzleTrigger.puzzleSolved = true;

        /*
        foreach (Numbers no in numbers)
        {
            no.Disable();
        }
        */
    }
}

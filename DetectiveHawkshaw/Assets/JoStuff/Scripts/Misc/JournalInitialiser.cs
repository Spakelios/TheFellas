using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalInitialiser : MonoBehaviour
{
    public static GameObject journal;

    private void Awake()
    {
        journal = GameObject.FindWithTag("Journal");
    }
}

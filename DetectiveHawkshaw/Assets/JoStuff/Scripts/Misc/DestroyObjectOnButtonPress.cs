using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnButtonPress : MonoBehaviour
{
    private GameObject journal;

    private void Start()
    {
        journal = GameObject.FindWithTag("Journal");
        Destroy(journal);
    }
}

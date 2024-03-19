using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsTracker : MonoBehaviour
{
    public int score;

    private void Start()
    {
        score = 0;
    }

    public void CheckScore()
    {
        if (score != 3) return;
        Debug.Log("All matched!");
    }
}

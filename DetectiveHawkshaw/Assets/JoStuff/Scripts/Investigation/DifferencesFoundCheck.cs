using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferencesFoundCheck : MonoBehaviour
{
    public OtherPuzzleTrigger puzzle;

    public void DiffCheck()
    {
        if (SpotTheDifferencePuzzle.found == 3)
        {
            puzzle.PuzzleSolved();
        }
    }
}

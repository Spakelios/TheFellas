using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawSolvedCheck : MonoBehaviour
{
    public static bool jigsawDone;
    public OtherPuzzleTrigger puzzle;

    public void CheckJigsaw()
    {
        if (!jigsawDone) return;
        jigsawDone = false;
        puzzle.PuzzleSolved();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInvestigationStuff : MonoBehaviour
{
    private InitialisationScript initialiser;
    private void Start()
    {
        Cursor.visible = true;
        InvestigationDialogueTrigger.isExamined.Clear();
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Intensity", -InvestigationDialogueTrigger.plus);
        InvestigationDialogueTrigger.plus = 0;

        PuzzleTrigger.puzzleSolved = false;
        OtherPuzzleTrigger.puzzleSolved = false;

        var dia = GameObject.FindWithTag("DialogueManager");
        var invest = GameObject.FindWithTag("InvestigationCanvas");
        var room = GameObject.FindWithTag("RoomLoader");
        var music = GameObject.FindWithTag("InvestigationMusic");
        
        /*
        var list = GameObject.FindGameObjectsWithTag("Initialiser");
        
        Destroy(initialiser.dia);
        Destroy(initialiser.inter);
        Destroy(initialiser.invest);
        Destroy(initialiser.room);
        foreach (var g in list)
        {
            Destroy(g);
        }
        */
        
        Destroy(dia);
        Destroy(invest);
        Destroy(room);
        Destroy(music);
        
    }
}

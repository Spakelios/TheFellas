using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceUponEntry : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    private static int plus = 0;

    public Evidence evidenceStats;
    
    private void Start()
    {
        if (InvestigationDialogueTrigger.isExamined.Contains(evidenceStats)) return;
        
        StartDialogue();
    }

    private void StartDialogue()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.evidenceDialogue = true;
        plus++;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Intensity", plus);
        InvestigationDialogueTrigger.isExamined.Add(evidenceStats);
        
        dialogueManager.evidenceStats = evidenceStats;
        dialogueManager.StartDialogue(dialogue);
    }
    
}

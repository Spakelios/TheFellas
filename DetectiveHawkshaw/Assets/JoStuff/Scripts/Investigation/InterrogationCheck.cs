using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterrogationCheck : MonoBehaviour
{
    //public InvestigationDialogueTrigger investigation;
    //[SerializeField] private List<int> chapterEvidence;
    //public static List<int> newEvidence;
    public int evidenceCount;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    public InitialisationScript initialiser;
    public ChapterType chapterType;
    
    //public string sceneName;

    //private AudioSource music;

    public enum ChapterType
    {
        Sandwich,
        Antique,
        Break,
        Confront
    }
    

    private void Start()
    {
        //music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        initialiser = FindObjectOfType<InitialisationScript>();
        evidenceCount = initialiser.caseData.caseEvidence.Count;
        dialogueManager = FindObjectOfType<DialogueManager>();
        
    }

    public void CheckEvidence()
    {
        /*
        print(InvestigationDialogueTrigger.isExamined);

        if (InvestigationDialogueTrigger.isExamined.Contains(1) &&
            InvestigationDialogueTrigger.isExamined.Contains(2) &&
            InvestigationDialogueTrigger.isExamined.Contains(3) && 
            InvestigationDialogueTrigger.isExamined.Contains(4))
        {
            //SceneManager.LoadScene("InterrogationScene");
            //VNToInvestLoader.instance.LoadLevel("InterrogationScene");
            //RoomLoader.instance.LoadLevel(sceneName);
            //music.Stop();
        }
        */
        
        print(InvestigationDialogueTrigger.isExamined.Count);

        if (InvestigationDialogueTrigger.isExamined.Count != evidenceCount) return;
        if (dialogueManager.allEvidence) return;
        
        dialogueManager.allEvidence = true;
        if (chapterType == ChapterType.Break)
        {
            dialogueManager.ChapterType = DialogueManager.chapterType.Break;
        }
        
        else if (chapterType == ChapterType.Confront)
        {
            dialogueManager.ChapterType = DialogueManager.chapterType.Confront;
        }
        
        else if (chapterType == ChapterType.Sandwich)
        {
            dialogueManager.ChapterType = DialogueManager.chapterType.Sandwich;
        }
        
        dialogueManager.StartDialogue(dialogue);

    }

}

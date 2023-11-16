using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterrogationCheck : MonoBehaviour
{
    public InvestigationDialogueTrigger investigation;
    private List<int> evidenceCheck;
    public static List<int> newEvidence;

    private void Start()
    {
        evidenceCheck = new List<int>()
        {
            1, 2, 3, 4
        };
    }

    public void CheckEvidence()
    {
        
        print(InvestigationDialogueTrigger.isExamined);

        if (InvestigationDialogueTrigger.isExamined.Contains(1) &&
            InvestigationDialogueTrigger.isExamined.Contains(2) &&
            InvestigationDialogueTrigger.isExamined.Contains(3) && 
            InvestigationDialogueTrigger.isExamined.Contains(4))
        {
            SceneManager.LoadScene("InterrogationScene");
        }
    }

}

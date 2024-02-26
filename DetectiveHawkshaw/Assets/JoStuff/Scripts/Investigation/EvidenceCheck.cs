using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EvidenceCheck : MonoBehaviour
{
    /*
    public GameObject breadcrumbs; //2
    public GameObject cucumbers; //1
    public GameObject calendar; //3
    public GameObject toilet; //4
    */
    
    public GameObject[] caseEvidencesLeftPage;
    public Image[] caseEvidencesLeftPageImages;
    public Image[] caseEvidencesRightPage;
    public TextMeshProUGUI[] EvidenceNames;
    public TextMeshProUGUI[] EvidenceDescriptions;

    public Evidence[] scriptableObjects;
    
    

    private void Start()
    {
        /*
        breadcrumbs.SetActive(false);
        cucumbers.SetActive(false);
        calendar.SetActive(false);
        toilet.SetActive(false);
        */

        foreach (var evidence in caseEvidencesLeftPage)
        {
            evidence.SetActive(false);
        }

    }
    public void Evidence()
    {
        /*
        if (InvestigationDialogueTrigger.isExamined.Contains(2))
        {
            breadcrumbs.SetActive(true);
        }

        if (InvestigationDialogueTrigger.isExamined.Contains(1))
        {
            cucumbers.SetActive(true);
        }

        if (InvestigationDialogueTrigger.isExamined.Contains(3))
        {
            calendar.SetActive(true);
        }

        if (InvestigationDialogueTrigger.isExamined.Contains(4))
        {
            toilet.SetActive(true);
        }
        */

        if (InvestigationDialogueTrigger.isExamined.Contains(1))
        {
            caseEvidencesLeftPage[0].SetActive(true);
            caseEvidencesLeftPageImages[0].sprite = scriptableObjects[0].evidencePolaroid;
            caseEvidencesRightPage[0].sprite = scriptableObjects[0].evidencePolaroid;
            EvidenceNames[0].text = scriptableObjects[0].evidenceName;
            EvidenceDescriptions[0].text = scriptableObjects[0].evidenceDescription;
        }
        
        if (InvestigationDialogueTrigger.isExamined.Contains(2))
        {
            caseEvidencesLeftPage[1].SetActive(true);
            caseEvidencesLeftPageImages[1].sprite = scriptableObjects[1].evidencePolaroid;
            caseEvidencesRightPage[1].sprite = scriptableObjects[1].evidencePolaroid;
            EvidenceNames[1].text = scriptableObjects[1].evidenceName;
            EvidenceDescriptions[1].text = scriptableObjects[1].evidenceDescription;
        }
        
        if (InvestigationDialogueTrigger.isExamined.Contains(3))
        {
            caseEvidencesLeftPage[2].SetActive(true);
            caseEvidencesLeftPageImages[2].sprite = scriptableObjects[2].evidencePolaroid;
            caseEvidencesRightPage[2].sprite = scriptableObjects[2].evidencePolaroid;
            EvidenceNames[2].text = scriptableObjects[2].evidenceName;
            EvidenceDescriptions[2].text = scriptableObjects[2].evidenceDescription;
        }
        
        if (InvestigationDialogueTrigger.isExamined.Contains(4))
        {
            caseEvidencesLeftPage[3].SetActive(true);
            caseEvidencesLeftPageImages[3].sprite = scriptableObjects[3].evidencePolaroid;
            caseEvidencesRightPage[3].sprite = scriptableObjects[3].evidencePolaroid;
            EvidenceNames[3].text = scriptableObjects[3].evidenceName;
            EvidenceDescriptions[3].text = scriptableObjects[3].evidenceDescription;
        }
    }
}

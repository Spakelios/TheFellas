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

    public List<GameObject> caseEvidencesLeftPage;
    public List<Image> caseEvidencesLeftPageImages;
    public List<Image> caseEvidencesRightPage;
    public List<TextMeshProUGUI> EvidenceNames;
    public List<TextMeshProUGUI> EvidenceDescriptions;
    public List<Evidence> chapterEvidence;

    private void Awake()
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
        
        if (InvestigationDialogueTrigger.isExamined.Contains(1))
        {
            caseEvidencesLeftPage[0].SetActive(true);
            caseEvidencesLeftPageImages[0].sprite = chapterEvidence[0].evidencePolaroid;
            caseEvidencesRightPage[0].sprite = chapterEvidence[0].evidencePolaroid;
            EvidenceNames[0].text = chapterEvidence[0].evidenceName;
            EvidenceDescriptions[0].text = chapterEvidence[0].evidenceDescription;
        }
        
        if (InvestigationDialogueTrigger.isExamined.Contains(2))
        {
            caseEvidencesLeftPage[1].SetActive(true);
            caseEvidencesLeftPageImages[1].sprite = chapterEvidence[1].evidencePolaroid;
            caseEvidencesRightPage[1].sprite = chapterEvidence[1].evidencePolaroid;
            EvidenceNames[1].text = chapterEvidence[1].evidenceName;
            EvidenceDescriptions[1].text = chapterEvidence[1].evidenceDescription;
        }
        
        if (InvestigationDialogueTrigger.isExamined.Contains(3))
        {
            caseEvidencesLeftPage[2].SetActive(true);
            caseEvidencesLeftPageImages[2].sprite = chapterEvidence[2].evidencePolaroid;
            caseEvidencesRightPage[2].sprite = chapterEvidence[2].evidencePolaroid;
            EvidenceNames[2].text = chapterEvidence[2].evidenceName;
            EvidenceDescriptions[2].text = chapterEvidence[2].evidenceDescription;
        }
        
        if (InvestigationDialogueTrigger.isExamined.Contains(4))
        {
            caseEvidencesLeftPage[3].SetActive(true);
            caseEvidencesLeftPageImages[3].sprite = chapterEvidence[3].evidencePolaroid;
            caseEvidencesRightPage[3].sprite = chapterEvidence[3].evidencePolaroid;
            EvidenceNames[3].text = chapterEvidence[3].evidenceName;
            EvidenceDescriptions[3].text = chapterEvidence[3].evidenceDescription;
        }
        
        */

        
        foreach (var e in chapterEvidence)
        {
            if (InvestigationDialogueTrigger.isExamined.Contains(e))
            {
                for (int i = 0; i < InvestigationDialogueTrigger.isExamined.Count; i++)
                {
                    caseEvidencesLeftPage[i].SetActive(true);
                    caseEvidencesLeftPageImages[i].sprite = InvestigationDialogueTrigger.isExamined[i].evidencePolaroid;
                    caseEvidencesRightPage[i].sprite = InvestigationDialogueTrigger.isExamined[i].evidencePolaroid;
                    EvidenceNames[i].text = InvestigationDialogueTrigger.isExamined[i].evidenceName;
                    EvidenceDescriptions[i].text = InvestigationDialogueTrigger.isExamined[i].evidenceDescription;
                }
            }
        }
        
        
        
    }
}

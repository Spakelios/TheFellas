using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceCheck : MonoBehaviour
{
    public GameObject breadcrumbs; //2
    public GameObject cucumbers; //1
    public GameObject calendar; //3
    public GameObject toilet; //4

    private void Start()
    {
        breadcrumbs.SetActive(false);
        cucumbers.SetActive(false);
        calendar.SetActive(false);
        toilet.SetActive(false);
    }
    public void Evidence()
    {
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
    }
}

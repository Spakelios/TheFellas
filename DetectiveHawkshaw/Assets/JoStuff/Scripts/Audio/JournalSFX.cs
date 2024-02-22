using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalSFX : MonoBehaviour
{
    public void OpenJournal()
    {
        FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.journalOpen, transform.position);
    }

    public void FlickThroughJournal()
    {
        FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.journalFlick, transform.position);
    }

    public void CloseJournal()
    {
        FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.journalClose, transform.position);
    }
    
}

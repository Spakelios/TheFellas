using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterrogationCheck : MonoBehaviour
{
    public InvestigationDialogueTrigger investigation;
    //[SerializeField] private List<int> chapterEvidence;
    //public static List<int> newEvidence;
    [SerializeField] private int evidenceCount;
    
    public string sceneName;

    //private AudioSource music;

    private void Start()
    {
        //music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        
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

        if (InvestigationDialogueTrigger.isExamined.Count != evidenceCount)
        {
            Debug.Log("Not all evidence found!");
        }

        else
        {
            Debug.Log("All evidence found!");
        }


    }

}

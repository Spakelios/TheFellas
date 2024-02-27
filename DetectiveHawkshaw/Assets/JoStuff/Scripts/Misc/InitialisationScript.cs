using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PUT IN EACH SCENE, MAKING SURE THE CASEDATA ALIGNS WITH THE CORRESPONDING CASE
public class InitialisationScript : MonoBehaviour
{
    public CaseList caseData;
    public GameObject investigationCanvas;
    public GameObject dialogueManager;
    public GameObject interrogationCheck;
    public GameObject roomLoader;

    public GameObject invest;
    public GameObject dia;
    public GameObject inter;
    public GameObject room;

    private void Awake()
    {
        //checks to see if each object is in the scene & instantiates it if not
        //should be able to load in on scenes that aren't marked as "Initial_*Insert Scene Name*"
        
        invest = GameObject.FindWithTag("InvestigationCanvas");

        if (invest == null)
        {
            invest = Instantiate(investigationCanvas);
        }
        
        dia = GameObject.FindWithTag("DialogueManager");

        if (dia == null)
        {
            dia = Instantiate(dialogueManager);
        }

        inter = GameObject.FindWithTag("InterrogationCheck");

        if (inter == null)
        {
            inter = Instantiate(interrogationCheck);
        }

        room = GameObject.FindWithTag("RoomLoader");

        if (room == null)
        {
            room = Instantiate(roomLoader);
        }
        
    }

    private void DestroyObjects()
    {
        Destroy(invest);
        Destroy(dia);
        Destroy(inter);
        Destroy(room);
        Destroy(this);
    }
}

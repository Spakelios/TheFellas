using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EvidenceData", menuName = "ScriptableObjects/Evidence", order = 1)]
public class Evidence : ScriptableObject
{
    public string evidenceName;
    [TextArea(3, 10)]
    public string evidenceDescription;
    
    public Sprite evidencePic;
    public Sprite evidencePic2; //for evidence that might have a zoom-in, e.g., the calendar
    public Sprite evidencePolaroid;
    public int evidenceIDNumber;
}

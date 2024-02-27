using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CaseData", menuName = "ScriptableObjects/CaseFile", order = 2)]

public class CaseList : ScriptableObject
{
    public List<Evidence> caseEvidence;
    public string interrogationSceneName;
}

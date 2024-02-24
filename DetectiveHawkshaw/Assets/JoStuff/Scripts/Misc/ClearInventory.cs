using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearInventory : MonoBehaviour
{
    public void Clear()
    {
        InvestigationDialogueTrigger.isExamined.Clear();
    }
}

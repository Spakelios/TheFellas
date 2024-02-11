using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public SerializableDictionary<int, bool> EvidenceCollected;


    public GameData()
    {
        EvidenceCollected = new SerializableDictionary<int, bool>();
    }
}

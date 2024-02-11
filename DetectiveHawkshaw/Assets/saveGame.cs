using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveGame : MonoBehaviour
{
    public void OnSaveGameClicked()
    {
        DataPersistenceManager.instance.SaveGame();
    }
}

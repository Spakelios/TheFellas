using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestToInterrogation : MonoBehaviour
{
    public string sceneName;

    public void GoToInterrogation()
    {
        RoomLoader.instance.LoadLevel(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData

{
    public int x;
    public long lastUpdated;
    public string currentSceneName;

    public GameData() 
    {
        // default for starting a new game
        currentSceneName = "DemoTest1";
    }
    
}
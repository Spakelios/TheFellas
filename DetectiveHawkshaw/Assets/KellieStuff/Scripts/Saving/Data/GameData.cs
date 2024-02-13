using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData

{
    public int x;
    public long lastUpdated;
// alternatively, you could use an int sceneIndex
    public string currentSceneName;
  

    public GameData()
    { 
        currentSceneName = "DemoTest1";
        
    }

}
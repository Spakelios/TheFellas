using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class GameData

{
    public int x;
    public long lastUpdated;
// alternatively, you could use an int sceneIndex
    public string currentSceneName;
    public static string scene;
    public int Num;
    public bool On;
    

    public GameData() 
    {
        // default for starting a new game
        currentSceneName = "DemoTest1";
        On = false;

    }
}
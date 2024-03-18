using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class onOff : MonoBehaviour
{
    public GameData Ohboy;
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("DemoTest1"))
        {
            
        }
        if (scene.name.Equals("InterrogationScene 3") && scene.name.Equals("Destroyed Lobby (Initial)"))
        {
            Ohboy.On = true;
        }
    }
}

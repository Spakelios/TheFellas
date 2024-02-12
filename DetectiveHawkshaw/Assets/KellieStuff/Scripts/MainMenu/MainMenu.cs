using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button Continue;
    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGamedata())
        {
            Continue.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
       Debug.Log("play");
       DataPersistenceManager.instance.NewGame();
       SceneManager.LoadSceneAsync("DemoTest1");
       
    }


    public void OnContinueClicked()
    {
        Debug.Log("continue");
        SceneManager.LoadSceneAsync("Initial_Lobby");
    }
}

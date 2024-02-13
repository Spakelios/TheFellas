using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveGame : MonoBehaviour
{
    public void OnSaveGameClicked()
    {
        SceneManager.LoadSceneAsync("StartScreen");
        Time.timeScale = 1;
        Destroy(GameObject.Find("JournalCanvas"));
    }
}

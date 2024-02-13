using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void newlevel ()
    {
        SceneManager.LoadScene("DemoTest1");
        
    }
    
    public void newlevel2 ()
    {
        SceneManager.LoadScene("Level Select");
    }
    
    public void newlevel3()
    {
        SceneManager.LoadScene("Coming soon");
    }
   
    public void Back()
    {
        SceneManager.LoadScene("StartScreen");
    }  
    
    public void Level()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}

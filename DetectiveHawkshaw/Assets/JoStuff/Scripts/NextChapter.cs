using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextChapter : MonoBehaviour
{
    public void Ch1Load()
    {
        SceneManager.LoadScene("Initial Brief Ch. 1");
    }
    
    public void Ch2Load()
    {
        SceneManager.LoadScene("Initial Brief Ch. 2");
    }
    
    public void Ch3Load()
    {
        SceneManager.LoadScene("Initial Brief Ch. 3");
    }
    
    public void EpilogueLoad()
    {
        SceneManager.LoadScene("Epilogue");
    }
}

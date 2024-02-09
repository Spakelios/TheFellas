using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool isPaused;

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Play()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
}

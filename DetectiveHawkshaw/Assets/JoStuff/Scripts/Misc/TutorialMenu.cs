using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    private void Start()
    {
        PauseGame.isPaused = true;
    }

    public void UnPause()
    {
        PauseGame.isPaused = false;
    }
}

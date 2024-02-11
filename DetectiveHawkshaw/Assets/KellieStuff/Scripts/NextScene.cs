using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void next()
    {
        VNToInvestLoader.instance.LoadLevel("Initial_Lobby");
    }
    
    public void endScreen()
    {
        SceneManager.LoadScene("End Screen");
    }
}

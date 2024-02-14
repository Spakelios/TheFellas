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
    public void ChOneInvest()
    {
        VNToInvestLoader.instance.LoadLevel("Initial Scene Ch. 1");
    }
    
    public void ChTwoInvest()
    {
        VNToInvestLoader.instance.LoadLevel("Initial Scene Ch. 2");
    }
    
    public void ChThreeInvest()
    {
        VNToInvestLoader.instance.LoadLevel("Initial Scene Ch. 3");
    }
}

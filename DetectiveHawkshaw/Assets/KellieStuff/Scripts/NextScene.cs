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
    public void next1()
    {
        VNToInvestLoader.instance.LoadLevel("(1) Start");
    }  
    public void next2()
    {
        VNToInvestLoader.instance.LoadLevel("Chap 2 Start");
    }   
    public void next3()
    {
             VNToInvestLoader.instance.LoadLevel("Chap 3 Start"); 
    }  
    public void next4()
    {
             VNToInvestLoader.instance.LoadLevel("Chap 3.5"); 
    }
    
    public void endScreen()
    {
        SceneManager.LoadScene("End Screen");
    }
    public void endScreen1()
    {
        SceneManager.LoadScene("Ending1");
    } 
    public void endScreen2()
    {
        SceneManager.LoadScene("End2");
    } 
    public void endScreen3()
    {
        SceneManager.LoadScene("End3");
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

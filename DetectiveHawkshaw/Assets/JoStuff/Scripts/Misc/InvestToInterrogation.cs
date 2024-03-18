using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvestToInterrogation : MonoBehaviour
{
    public InitialisationScript initialiser;
    public string sceneName;
    
    public Animator transition;
    public float transitionTime = 1f;

    private void Awake()
    {
        initialiser = FindObjectOfType<InitialisationScript>();
        sceneName = initialiser.caseData.interrogationSceneName;
    }

    
    public void GoToInterrogation()
    {
        RoomLoader.instance.LoadLevel(sceneName);
    }
    
    
    public void LoadLevel()
    {
        StartCoroutine(LoadNamedLevel(sceneName));
    }

    IEnumerator LoadNamedLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(levelName);
        //initialiser.DestroyObjects();
    }
    
    
    /*
    private void DestroyObjects()
    {
        var list = GameObject.FindGameObjectsWithTag("Initialiser");
        Cursor.visible = true;
        
        Destroy(initialiser.dia);
        Destroy(initialiser.inter);
        Destroy(initialiser.room);
        foreach (var g in list)
        {
            Destroy(g);
        }
        
        Destroy(initialiser.invest);

    }
    */
    
}

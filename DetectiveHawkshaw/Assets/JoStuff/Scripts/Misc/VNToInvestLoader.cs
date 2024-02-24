using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VNToInvestLoader : MonoBehaviour
{
    public static VNToInvestLoader instance;

    public Animator transition;
    public float transitionTime = 1f;


    private void Awake()
    {
        instance = this;
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadNamedLevel(levelName));
    }

    IEnumerator LoadNamedLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(levelName);

    }
}

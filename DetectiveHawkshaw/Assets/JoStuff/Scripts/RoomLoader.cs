using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomLoader : MonoBehaviour
{
    public static RoomLoader instance;

    public Animator transition;
    public float transitionTime = 1f;
    
    public AudioSource doorOpen;
    public AudioSource doorClose;
    

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadNamedLevel(levelName));
    }

    IEnumerator LoadNamedLevel(string levelName)
    {
        doorOpen.Play();
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(levelName);
        
        transition.SetTrigger("End");
        doorClose.Play();

    }
}

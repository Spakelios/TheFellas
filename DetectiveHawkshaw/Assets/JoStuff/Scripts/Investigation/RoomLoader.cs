using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomLoader : MonoBehaviour
{
    public static RoomLoader instance;

    public Animator transition;
    public float transitionTime = 1f;

    [SerializeField]private GameObject journal;

    //public AudioSource doorOpen;
    //public AudioSource doorClose;
    
    

    private void Awake()
    {
        instance = this;
        journal = GameObject.FindWithTag("Journal");
        journal.SetActive(true);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadNamedLevel(levelName));
    }

    IEnumerator LoadNamedLevel(string levelName)
    {
        
        transition.SetTrigger("Start");
        FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.doorOpen, transform.position);
        journal.SetActive(false);

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(levelName);
        
        transition.SetTrigger("End");
        FMODAudioManager.instance.PlayOneShot(FMODEvents.instance.doorClose, transform.position);
        journal.SetActive(true);


    }
}

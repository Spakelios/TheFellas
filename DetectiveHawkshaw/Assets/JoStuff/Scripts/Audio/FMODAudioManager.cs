using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class FMODAudioManager : MonoBehaviour
{ 
    public static FMODAudioManager instance { get; private set; }

    private EventInstance musicEventInstance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Girl why is there more than one AudioManager in the scene? Take it out smh");
        }

        instance = this;
    }


    public void PlayOneShot(EventReference sound, Vector3 worldPos) //for one-shot sfx, such as picking up evidence
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    private void Start()
    {
        InitialiseMusic(FMODEvents.instance.investigationMusic);
    }

    private void InitialiseMusic(EventReference musicReference)
    {
        musicEventInstance = RuntimeManager.CreateInstance(musicReference);
        musicEventInstance.start();
    }
}

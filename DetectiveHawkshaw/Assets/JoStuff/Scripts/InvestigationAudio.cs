using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationAudio : MonoBehaviour
{
    public AudioSource audio;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        audio = GetComponent<AudioSource>();
        
        if (audio.isPlaying)
        {
            StopMusic();
        }

        else
        {
            PlayMusic();
        }
    }

    private void PlayMusic()
    {
        audio.Play();
    }

    private void StopMusic()
    {
        audio.Stop();
    }
    
}

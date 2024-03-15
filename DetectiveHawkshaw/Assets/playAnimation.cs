using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playAnimation : MonoBehaviour
{
  
    void Start()
    {
        StartCoroutine("play");
    }


    IEnumerator play()
    {
        yield return new WaitForSeconds(12f);

        SceneManager.LoadScene("StartScreen");

    }
}

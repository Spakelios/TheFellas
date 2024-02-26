using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shake());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Shake()
    {
        yield return new WaitForSeconds(5);
        
        CineMachineShake.Instance.ScreenShake(1.5f, 0.4f);

        yield return new WaitForSeconds(3);
            
        CineMachineShake.Instance.ScreenShake(0f, 0f);
    }
}

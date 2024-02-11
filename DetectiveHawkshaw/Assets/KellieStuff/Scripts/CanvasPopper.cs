using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPopper : MonoBehaviour
{
  public GameObject Anim;

  public void Update()
  {
    StartCoroutine("Invest");
  }
  

  IEnumerator Invest()
  {
    yield return new WaitForSeconds(4);
    
    Destroy(Anim);
  }
}


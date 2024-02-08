using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popin : MonoBehaviour
{
  public GameObject dialogueBox;
  private void Update()
  {
    StartCoroutine("startDialogue");
  }

  private IEnumerator startDialogue()
  {
    yield return new WaitForSeconds(8);
    dialogueBox.SetActive(true);
    
  }
}

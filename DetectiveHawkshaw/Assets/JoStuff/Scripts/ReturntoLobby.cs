using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturntoLobby : MonoBehaviour
{
    public void ReturnToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}

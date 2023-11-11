using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToRoom : MonoBehaviour
{
    private Vector2 mousePos;
    public GameObject eyePrefab;
    private GameObject eye;
    private bool eyeSpawned;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (eyeSpawned)
        {
            eye.transform.position = mousePos;
        }
    }
    
    private void OnMouseEnter()
    {
        Cursor.visible = false;
        eye = Instantiate(eyePrefab);
        eyeSpawned = true;
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseExit();
            SceneManager.LoadScene(sceneName);
        }
    }
    
    
    
    private void OnMouseExit()
    {
        Cursor.visible = true;
        Destroy(eye);
        eyeSpawned = false;
        
    }
}

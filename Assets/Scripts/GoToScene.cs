using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public bool isAutomatic;
    private bool manualEnter;

    private void Update()
    {
        if(!isAutomatic && !manualEnter)
        {
            manualEnter = Input.GetButtonDown("Fire1");
        }


    }


    public string sceneName = "Name";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (isAutomatic)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
           
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if(!isAutomatic && manualEnter)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

}

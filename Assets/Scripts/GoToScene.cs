using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public bool isAutomatic;
    private bool manualEnter;


    public string uuid;
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
        Teleport(other.name);
           
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Teleport(other.name);
    }

    private void  Teleport(string objname)
    {
        if (objname == "Player")
        {
            if(isAutomatic || !isAutomatic && manualEnter) 
            {
                FindObjectOfType<PlayerController>().nextToUUID = uuid;
                SceneManager.LoadScene(sceneName);
            }
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAppears : MonoBehaviour
{
    public GameObject MainMenu_prefab;
    public GameObject player;
    void Update(){
     if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            
            if (MainMenu_prefab.activeSelf == false)
            {
                MainMenu_prefab.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
            }
            else
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                MainMenu_prefab.SetActive(false);
            }
        }
    }
}

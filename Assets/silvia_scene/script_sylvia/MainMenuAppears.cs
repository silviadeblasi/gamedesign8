using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAppears : MonoBehaviour
{
    public GameObject MainMenu_prefab;
    void Update(){
     if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Debug.Log("Escape key was pressed");
            if (MainMenu_prefab.activeSelf == false)
            {
                Debug.Log("MainMenu_prefab is active");
                MainMenu_prefab.SetActive(true);
            }
            else
            {
                Debug.Log("MainMenu_prefab is not active");
                MainMenu_prefab.SetActive(false);
            }
        }
    }
}

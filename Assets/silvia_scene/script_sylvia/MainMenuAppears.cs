using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAppears : MonoBehaviour
{
    public GameObject MainMenu_prefab;
    public GameObject Inventory_prefab;
    public GameObject Map_prefab;
    public GameObject player;
    void Update(){
        
        //tasto esc apro il menu principale
    /* if (Input.GetKeyDown(KeyCode.Escape)) 
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
        }*/

        //tasto i apro l'inventario 
        if(Input.GetKeyDown(KeyCode.I))
        { 
            if (Inventory_prefab.activeSelf == false)
            {
                Inventory_prefab.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
            }
            else
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                Inventory_prefab.SetActive(false);
            }
        }

        //tasto m apro la mappa
        if(Input.GetKeyDown(KeyCode.M)){
            if (Map_prefab.activeSelf == false)
            {
                Map_prefab.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
            }
            else
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                Map_prefab.SetActive(false);
            }
        }
    }
}

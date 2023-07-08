using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public static bool inventoryPanelActive = false;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryPanelActive)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        inventoryPanel.SetActive(false);
        Time.timeScale = 1f;
        inventoryPanelActive = false;
    }

    void Pause()
    {
        inventoryPanel.SetActive(true);
        Time.timeScale = 0f;
        inventoryPanelActive = true;
    }
}

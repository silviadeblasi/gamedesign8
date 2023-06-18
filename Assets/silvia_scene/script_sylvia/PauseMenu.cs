using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool MainMenuActive = false;
    public GameObject MainMenu;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MainMenuActive)
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
        MainMenu.SetActive(false);
        Time.timeScale = 1f;
        MainMenuActive = false;
    }
    void Pause()
    {
        MainMenu.SetActive(true);
        Time.timeScale = 0f;
        MainMenuActive = true;

    }
    
}

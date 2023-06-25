using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    /* public static bool MainMenuActive = false;
     public GameObject MainMenu;
     public Button ResumeButton;
     //private float opacity;

     //private Selectable selectable;
     private ColorBlock originalColors;

     /*private void Start()
     {
         selectable = ResumeButton.GetComponent<Selectable>();
         originalColors = selectable.colors;


     }*/


    public static bool MainMenuActive = false;
    public GameObject MainMenu;
    public Button ResumeButton;
    
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
        //SetSelectedOpacity(0f);
        //ResumeButton.GetComponent<Image>().enabled = true;
    }
    /*
    private void SetSelectedOpacity(float opacity)
    {
        ColorBlock newColors = originalColors;
        Color selectedColor = newColors.selectedColor;
        selectedColor.a = opacity;
        newColors.selectedColor = selectedColor;
        selectable.colors = newColors;

        Color pressedColor = newColors.pressedColor;
        pressedColor.a = opacity;
        newColors.pressedColor = pressedColor;
    }


    /*private void SetHighlightedColor(float opacity)
    {
        ColorBlock newColors = originalColors;
        Color highlightedColor = newColors.highlightedColor;

        highlightedColor.a = opacity;

        newColors.highlightedColor = highlightedColor;
        selectable.colors = newColors;
    }

    public GameObject mainMenuPanel;
    private Image buttonImage;
    private Color originalColor;

    private bool isMainMenuActive = false;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color;
        SetMainMenuActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMainMenu();

        }
    }
    private void ToggleMainMenu()
    {
        isMainMenuActive = !isMainMenuActive;
        SetMainMenuActive(isMainMenuActive);
    }

    private void SetMainMenuActive(bool isActive)
    {
        mainMenuPanel.SetActive(isActive);

        if (isActive)
        {
            // Abilita l'immagine di sfondo del pulsante "Resume"
            buttonImage.enabled = true;
        }
        else
        {
            // Disabilita l'immagine di sfondo del pulsante "Resume"
            buttonImage.enabled = false;
        }
    }

    public void OnResumeButtonEnter()
    {
        // Abilita l'immagine di sfondo del pulsante "Resume" quando ci passi sopra col mouse
        buttonImage.color = originalColor;
    }

    public void OnResumeButtonExit()
    {
        // Disabilita l'immagine di sfondo del pulsante "Resume" quando il mouse esce dal pulsante
        if (!isMainMenuActive)
        {
            buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        }
    }

    public void OnResumeButtonClick()
    {
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isMainMenuActive = false;
    }
    */
}

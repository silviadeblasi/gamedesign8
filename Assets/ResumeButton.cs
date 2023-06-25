using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    

    private Image buttonImage;
    private Color originalColor;
    private bool isHighlighted;
    private bool isButtonVisible = true;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color;
    }



    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isButtonVisible = !isButtonVisible;
            UpdateButtonImage();
        }
    }


    public void OnPointerEnter()
    {
        if (isButtonVisible)
        {
            isHighlighted = true;
            UpdateButtonImage();
        }
    }

    public void OnPointerExit()
    {
        if (isButtonVisible)
        {
            isHighlighted = false;
            UpdateButtonImage();
        }
    }

    private void UpdateButtonImage()
    {
        if (isHighlighted)
        {
            buttonImage.color = originalColor;
        }
        else
        {
            buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        }
    }
}


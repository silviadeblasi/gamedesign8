using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        Debug.Log("heartContainers.initialValue: "+ heartContainers.initialValue);
        for(int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RuntimeValue / 2; // 2 perché considero ogni cuore come 2 punti vita
        for(int i = 0; i < heartContainers.initialValue; i++)
        {
            if(i <= tempHealth - 1)
            {
                // Full heart
                hearts[i].sprite = fullHeart;
            }
            else if(i >= tempHealth)
            {
                // Empty heart
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                // Half full heart
                hearts[i].sprite = halfFullHeart;
            }
        }
    }
}

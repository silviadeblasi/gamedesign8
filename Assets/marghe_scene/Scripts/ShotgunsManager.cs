using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunsManager : MonoBehaviour
{
    public Slider shotsSlider;
    public ShotgunsBar BarShots;

    void Start()
    {
        shotsSlider.maxValue = BarShots.maxShots;
        shotsSlider.value = 0;
        BarShots.currentShots = 0;
    }

    public void AddShots()
    {
        shotsSlider.value += 10;
        BarShots.currentShots += 10;

        if(shotsSlider.value > BarShots.maxShots)
        {
            shotsSlider.value = BarShots.maxShots;
            BarShots.currentShots = BarShots.maxShots;
        }
    }

    public void DecreaseShots()
    {
        shotsSlider.value -= 1;
        BarShots.currentShots -= 1;

        if(shotsSlider.value < 0)
        {
            shotsSlider.value = 0;
            BarShots.currentShots = 0;
        }
    }
}

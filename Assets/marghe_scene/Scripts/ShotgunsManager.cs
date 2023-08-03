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
        shotsSlider.value = BarShots.maxShots;
    }

    public void AddShots()
    {
        shotsSlider.value += 1;
        if(shotsSlider.value > BarShots.maxShots)
        {
            shotsSlider.value = BarShots.maxShots;
        }
    }

    public void DecreaseShots()
    {
        shotsSlider.value -= 1;
        if(shotsSlider.value < 0)
        {
            shotsSlider.value = 0;
        }
    }
}

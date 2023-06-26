
using UnityEngine;
using TMPro;

public class SoundOptionManager : MonoBehaviour
{
    public static float backgroundMusicVolume { get; private set; }
    public static float sfxVolume { get; private set; }

    /*[SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI sfxSliderText;*/


    public void BackgroundMusicSlider(float value)
    {
        backgroundMusicVolume = value;
       // musicSliderText.text= value.ToString();
    }
    public void sfxSlider(float value)
    {
        sfxVolume = value;
       // sfxSliderText.text = value.ToString();
    }
}


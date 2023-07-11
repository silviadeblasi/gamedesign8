using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOptionManager : MonoBehaviour
{
    public static float BgVolume { get; private set; }
    public static float SfxVolume { get; private set; }

   // [SerializeField] private TextMeshProUGUI musicSliderText;
    // [SerializeField] private TextMeshProUGUI sfxSliderText;


    public void BackgroundMusicSlider(float value)
    {

        BgVolume = value;

        // musicSliderText.text= value.ToString();
        SoundManager.Instance.UpdateMixerValue();

    }
    public void SfxSlider(float value)
    {
        SfxVolume = value;
        // sfxSliderText.text = value.ToString();
        SoundManager.Instance.UpdateMixerValue();
    } 
}


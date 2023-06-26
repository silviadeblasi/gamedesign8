
using UnityEngine;
using TMPro;

public class SoundOptionManager : MonoBehaviour
{
    public static float BgVolume { get; private set; }
    public static float sfxVolume { get; private set; }
    
    /*[SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI sfxSliderText;*/


    public void BackgroundMusicSlider(float value)
    {
        BgVolume = value;
        // musicSliderText.text= value.ToString();
        SoundManager.Instance.UpdateMixerValue();

    }
    public void sfxSlider(float value)
    {
        sfxVolume = value;
        // sfxSliderText.text = value.ToString();
        SoundManager.Instance.UpdateMixerValue();
    }
}


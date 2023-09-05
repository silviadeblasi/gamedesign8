using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptionManager : MonoBehaviour
{



	public AudioMixer audioMixer;
	public AudioMixerGroup BgMusic;
	public AudioMixerGroup SfxSound;
	//bg volume è il key valore float che io salvo nei preferiti. ovviamente deve essere uguale al volume del mixer
	//float bgVolume;
	//float sfxVolume; 

	public Slider backgroundSlider;
	public Slider soundEffectsSlider;

	/* public void Update()
	 {
		 audioMixer.GetFloat("BgVolume", out bgVolume);
		 PlayerPrefs.SetFloat("BgMusicVolume", bgVolume);

	 }*/


	/* private void Start()
	 {
		 // Impostare i valori iniziali degli slider
		 backgroundSlider.value = PlayerPrefs.GetFloat("BackgroundVolume", 0.5f);
		 soundEffectsSlider.value = PlayerPrefs.GetFloat("SoundEffectsVolume", 0.5f);
	 }*/

	public void SetVolumeBg(float volume)
	{

		audioMixer.SetFloat("BgVolume", Mathf.Log10(volume) * 20);

		//audioMixer.GetFloat("BgVolume", out bgVolume);
		PlayerPrefs.SetFloat("volumeBg", volume);
		PlayerPrefs.Save();
	}



	public void SetVolumeSfx(float volume)
	{
		audioMixer.SetFloat("SfxVolume", Mathf.Log10(volume) * 20);
		//audioMixer.GetFloat("SfxVolume", out sfxVolume);

		PlayerPrefs.SetFloat("volumeSfx", volume);
		PlayerPrefs.Save();

	}

}



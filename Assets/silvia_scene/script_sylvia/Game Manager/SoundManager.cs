using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{


	public static SoundManager instance;

	public AudioMixer audioMixer;

	public AudioMixerGroup BgMusic;
	public AudioMixerGroup SfxSound;

	public Sound[] sfx;

	public Sound[] bg;

	private AudioSource backgroundMusicSource;

	private AudioSource sfxSource;

	private float BgMusicVolume;
	public Slider BgSlider;
	private float SfxVolume;
	public Slider SfxSlider;

	public void Awake()
	{
		//inizializzo il default dei due valori
		PlayerPrefs.GetFloat("volumeBg", 1f);
		PlayerPrefs.GetFloat("volumeSfx", 1f);

		//sto if lo uso per non far detonare l oggetto ogni volta che cambio scena
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		//DontDestroyOnLoad(gameObject);

		//instance = this;

		// Crea e inizializza la sorgente audio per gli effetti sonori
		sfxSource = gameObject.AddComponent<AudioSource>();
		sfxSource.loop = true;
		sfxSource.playOnAwake = false;


		sfxSource.outputAudioMixerGroup = SfxSound;


		// Crea e inizializza la sorgente audio per la musica di sottofondo
		backgroundMusicSource = gameObject.AddComponent<AudioSource>();
		backgroundMusicSource.loop = true;
		backgroundMusicSource.playOnAwake = false;

		backgroundMusicSource.outputAudioMixerGroup = BgMusic;

		foreach (Sound s in sfx)
		{

			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

		}
	}

	public void PlayBackgroundMusic(string musicName, float Volume)
	{
		Sound sound = FindSound(bg, musicName, Volume);

		if (sound != null)
		{
			if (!backgroundMusicSource.isPlaying || backgroundMusicSource.clip != sound.clip)
			{
				backgroundMusicSource.clip = sound.clip;
				backgroundMusicSource.volume = sound.volume;
				backgroundMusicSource.Play();

				//credo che faccio matchare lo slider del volume con quello della scena precedente
				BgMusicVolume = PlayerPrefs.GetFloat("volumeBg");
				BgSlider.value = BgMusicVolume;


			}
		}
		else
		{
			Debug.LogWarning("Background music not found: " + musicName);
		}
	}

	public void PlaySoundEffect(string musicName, float Volume)
	{
		Sound sound = FindSound(sfx, musicName, Volume);

		if (sound != null)
		{
			// Riproduci il suono se il clip è stato trovato

			{
				sfxSource.PlayOneShot(sound.clip);
				sfxSource.volume = sound.volume;

				SfxVolume = PlayerPrefs.GetFloat("volumeSfx");
				SfxSlider.value = SfxVolume;
			}
		}
		else
		{
			Debug.LogWarning("Background music not found: " + musicName);
		}


	}
	private Sound FindSound(Sound[] sounds, string soundName, float vol)
	{
		foreach (Sound sound in sounds)
		{
			if (sound.nome == soundName)
			{
				sound.volume = vol;
				return sound;
			}
		}
		return null;
	}

	////////////////////// GESTIONE DEI VOLUMI TRAMITE AUDIO MIXER
	/// devo collegare gli array ai gruppi

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{

	public AudioClip[] soundEffects; // Array di clip audio degli effetti sonori
	public AudioClip[] backgroundMusic; // Array di clip audio della musica di sottofondo

	private AudioSource soundEffectSource; // Sorgente audio per gli effetti sonori
	private AudioSource backgroundMusicSource; // Sorgente audio per la musica di sottofondo

	[SerializeField] private Slider _bgSlider;
	[SerializeField] private Slider _sfxSlider;

	public static SoundManager Instance;

	private void Awake()
	{
		Instance = this;
		// Crea e inizializza la sorgente audio per gli effetti sonori
		soundEffectSource = gameObject.AddComponent<AudioSource>();
		soundEffectSource.playOnAwake = false;
		soundEffectSource.loop = true;

		//aggiungo l audio source all audio mixer per poter controllare il volume 
		//oundEffectSource.outputAudioMixerGroup = soundEffectsMixerGroup;

		// Crea e inizializza la sorgente audio per la musica di sottofondo
		backgroundMusicSource = gameObject.AddComponent<AudioSource>();
		backgroundMusicSource.loop = true;
		backgroundMusicSource.playOnAwake = false;

		//aggiungo l audio source all audio mixer per poter controllare il volume 
		//backgroundMusicSource.outputAudioMixerGroup = backgroundMixerGroup;
	}

	public void PlaySoundEffect(string soundName, float volume)
	{
		// Trova il clip audio corrispondente al nome passato come parametro
		AudioClip clip = FindClip(soundEffects, soundName);

		// Riproduci il suono se il clip è stato trovato
		if (clip != null)
		{
			soundEffectSource.PlayOneShot(clip);
			soundEffectSource.volume = volume;
		}
		else
		{
			Debug.LogWarning("Sound effect not found: " + soundName);
		}
	}

	public void PlayBackgroundMusic(string musicName, float volume)
	{
		// Trova il clip audio corrispondente al nome passato come parametro
		AudioClip clip = FindClip(backgroundMusic, musicName);

		// Avvia la riproduzione della musica di sottofondo se il clip è stato trovato
		if (clip != null)
		{
			if (!backgroundMusicSource.isPlaying || backgroundMusicSource.clip != clip)
			{
				backgroundMusicSource.clip = clip;
				backgroundMusicSource.Play();
			}
		}
		else
		{
			Debug.LogWarning("Background music not found: " + musicName);
		}
	}
	//non so se mi serve
	public void StopBackgroundMusic(string musicName)
	{
		AudioClip clip = FindClip(backgroundMusic, musicName);
		backgroundMusicSource.Stop();
	}

	private AudioClip FindClip(AudioClip[] clips, string clipName)
	{
		// Cerca il clip audio con il nome specificato nell'array di clip
		foreach (AudioClip clip in clips)
		{
			if (clip.name == clipName)
				return clip;
		}

		return null; // Ritorna null se il clip non viene trovato
	}

	public void ChangeVolumeBG()
	{
		//AudioListener.volume = _bgSlider.value;
		//Debug.Log("volume :" + _bgSlider.value);

		backgroundMusicSource.volume = _bgSlider.value;
	}

	public void ChangeVolumeSFX()
	{
		//AudioListener.volume = _sfxSlider.value;
		//Debug.Log("volume :" + _sfxSlider.value);

		soundEffectSource.volume = _sfxSlider.value;
	}

}
/*
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

	public void  ///////manca un awake/////()
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

}*/



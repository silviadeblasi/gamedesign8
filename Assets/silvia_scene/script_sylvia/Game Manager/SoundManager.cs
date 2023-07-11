using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] soundEffects; // Array di clip audio degli effetti sonori
    public AudioClip[] backgroundMusic; // Array di clip audio della musica di sottofondo
    [SerializeField] private AudioMixerGroup backgroundMixerGroup;
    [SerializeField] private AudioMixerGroup soundEffectsMixerGroup;
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
        //soundEffectSource.outputAudioMixerGroup = soundEffectsMixerGroup;

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
        if (clip != null){
            soundEffectSource.PlayOneShot(clip);
            soundEffectSource.volume = volume;
        }
        else{
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
    /*
    public void  UpdateMixerValue()
    {
        backgroundMixerGroup.audioMixer.SetFloat("BgVolume", Mathf.Log10(SoundOptionManager.BgVolume) * 20);
        soundEffectsMixerGroup.audioMixer.SetFloat("SfxVolume", Mathf.Log10(SoundOptionManager.SfxVolume) * 20);
    }*/

}



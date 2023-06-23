using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] soundEffects; // Array di clip audio degli effetti sonori
    public AudioClip[] backgroundMusic; // Array di clip audio della musica di sottofondo

    private AudioSource soundEffectSource; // Sorgente audio per gli effetti sonori
    private AudioSource backgroundMusicSource; // Sorgente audio per la musica di sottofondo

    private void Awake()
    {
        // Crea e inizializza la sorgente audio per gli effetti sonori
        soundEffectSource = gameObject.AddComponent<AudioSource>();
        soundEffectSource.playOnAwake = false;
        soundEffectSource.loop = true;

        // Crea e inizializza la sorgente audio per la musica di sottofondo
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource.loop = true;
        backgroundMusicSource.playOnAwake = false;
    }

    public void PlaySoundEffect(string soundName)
    {
        // Trova il clip audio corrispondente al nome passato come parametro
        AudioClip clip = FindClip(soundEffects, soundName);

        // Riproduci il suono se il clip è stato trovato
        if (clip != null)
            soundEffectSource.PlayOneShot(clip);
        else
            Debug.LogWarning("Sound effect not found: " + soundName);
    }

    public void PlayBackgroundMusic(string musicName)
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
}

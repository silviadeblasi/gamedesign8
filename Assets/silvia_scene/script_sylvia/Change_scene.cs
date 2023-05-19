using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_scene : MonoBehaviour
{
    public string nomeScenaDaCaricare;
    private Vector2 playerPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPosition = collision.transform.position;
            SceneManager.LoadScene(nomeScenaDaCaricare);
        }
    }

     private void Start()
    {
        // Controlla se esiste una posizione salvata
        if (PlayerPrefs.HasKey("PosizioneX") && PlayerPrefs.HasKey("PosizioneY"))
        {
            // Recupera la posizione salvata
            float posizioneX = PlayerPrefs.GetFloat("PosizioneX");
            float posizioneY = PlayerPrefs.GetFloat("PosizioneY");

            // Posiziona il personaggio nella posizione salvata
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector2(posizioneX, posizioneY);

            // Pulisci i dati di PlayerPrefs
            PlayerPrefs.DeleteKey("PosizioneX");
            PlayerPrefs.DeleteKey("PosizioneY");
        }
        else
        {
            // Nessuna posizione salvata, utilizza la posizione iniziale
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = playerPosition;
        }
    }

    private void OnDestroy()
    {
        // Salva la posizione corrente quando la scena viene distrutta (ad esempio, il cambio scena successivo)
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerPrefs.SetFloat("PosizioneX", player.transform.position.x);
        PlayerPrefs.SetFloat("PosizioneY", player.transform.position.y);
    }
}



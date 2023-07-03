using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openable : MonoBehaviour
{
    public GameObject[] comunicazione_comandi;
    public GameObject[] oggetti_da_attivare;
    public GameObject[] oggetti_da_disattivare;
    public SoundManager soundManager;
    public GameObject player;
    public  bool[] flag_opened;

    // Update is called once per frame
    void Update()
    {
    
    }
    //in questo on trigger stay metto tutti i layer con cui voglio interagire, nel senso di aprire o fare azioni
    //per interagire nel senso di aprire canvas --> usare interactable_object.cs
   private void OnTriggerStay2D(Collider2D other) {
        //il layer 11 è quello del baule, ogni oggetto ha il suo laure in questo modo posso attivare e disattivare i giusti oggetti e canvas
        if(other.gameObject.layer == 11){
            GameObject oggetto = FindOggetti(oggetti_da_attivare, "baule_aperto");
            GameObject oggetto2 = FindOggetti(oggetti_da_disattivare, "baule_chiuso");
            GameObject comandi = FindOggetti(comunicazione_comandi, "Interazione");
            GameObject comunicazione = FindOggetti(comunicazione_comandi, "comunicazione_machete");
            GameObject comunicazione_utilizzo = FindOggetti(comunicazione_comandi, "machete");
            if(Input.GetKeyDown(KeyCode.X)){
                soundManager.PlaySoundEffect("InterazioneOggetto", 0.5f);
                oggetto.SetActive(true);
                oggetto2.SetActive(false);
                comandi.SetActive(false);
                StartCoroutine(comunicazione_ogg_trovato(comunicazione, comunicazione_utilizzo, 0));
              }
        }
        //casa del cairo oggetto
        if(other.gameObject.layer == 14){
            GameObject oggetto = FindOggetti(oggetti_da_attivare, "mattonella_da_attivare");
            GameObject oggetto2 = FindOggetti(oggetti_da_disattivare, "mattonella_da_disattivare");
            GameObject comandi = FindOggetti(comunicazione_comandi, "Interazione");
            //GameObject comunicazione = FindOggetti(comunicazione_comandi, "comunicazione_porta");
            //GameObject comunicazione_utilizzo = FindOggetti(comunicazione_comandi, "porta");
            if(Input.GetKeyDown(KeyCode.X)){
                //soundManager.PlaySoundEffect("InterazioneOggetto", 0.5f);
                oggetto.SetActive(true);
                oggetto2.SetActive(false);
                comandi.SetActive(false);
                //StartCoroutine(comunicazione_ogg_trovato(comunicazione, comunicazione_utilizzo,index));
              }
        }
   }
   //coroutine che utilizzo per far comparire e scomparire il canvas che mi dice che ho trovato l'oggetto
   //la richiamo per ogni oggetto cambiando la comunicazione
    IEnumerator comunicazione_ogg_trovato(GameObject comunicazione, GameObject comunicazione_utilizzo, int index){
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerMovement>().enabled = false;
        comunicazione.SetActive(true);
        yield return new WaitForSeconds(3f);
        comunicazione.SetActive(false);
        yield return new WaitForSeconds(1f);
        comunicazione_utilizzo.SetActive(true);
        yield return new WaitForSeconds(3f);
        comunicazione_utilizzo.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        flag_opened[index] = true;
    }
    
    //funzione che mi permette di trovare un oggetto in un array di oggetti, lo uso per cercare oggetto da disattivare e attivare
    //e per cercare il canvas da attivare
    private GameObject FindOggetti(GameObject[] oggetti, string oggetto_name){
        foreach (GameObject oggetto in oggetti)
        {
            if(oggetto.name == oggetto_name){
                return oggetto;
            }
        }
        return null;
    }
   
}

//quello che devo fare è creare un layre e lettarlmente copiare questo codice e magari attivare oggetto trovato nell'inventario 

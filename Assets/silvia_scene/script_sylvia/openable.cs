using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openable : MonoBehaviour
{
    public GameObject[] comunicazione_comandi;
    public GameObject[] oggetti_da_attivare;
    public GameObject[] oggetti_da_disattivare;
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    //in questo on trigger stay metto tutti i layer con cui voglio interagire, nel senso di aprire o fare azioni
    //per interagire nel senso di aprire canvas --> usare interactable_object.cs
   private void OnTriggerStay2D(Collider2D other) {
        
        if(other.gameObject.layer == 11){
            GameObject oggetto = FindOggetti(oggetti_da_attivare, "baule_aperto");
            GameObject oggetto2 = FindOggetti(oggetti_da_disattivare, "baule_chiuso");
            GameObject comandi = FindOggetti(comunicazione_comandi, "Interazione");
            if(Input.GetKeyDown(KeyCode.X)){
                soundManager.PlaySoundEffect("InterazioneOggetto", 0.5f);
                oggetto.SetActive(true);
                oggetto2.SetActive(false);
                comandi.SetActive(false);
              }
        }
   }


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

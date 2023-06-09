using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scene_transition : MonoBehaviour
{
    public Vector2 player_position;
    public vector_value player_storage;
    public GameObject trigger; //questo è il trgger a cui è associato  lo script
    public GameObject interazione_non_completa;
    public openable opened;
    public interactable_object interactable; //verificare di aver trovato tutti i canvas prima di uscire dalla stanza
    private void OnTriggerEnter2D(Collider2D other) {

        //ingresso casa 
        //solo che io voglio vedere i layer e non i tag
        if(other.CompareTag("Player") && !other.isTrigger && trigger.gameObject.layer == 7){
            Scene_Loader.Load(Scene_Loader.Scene.Casa_sue);
            player_storage.initialValue = player_position;
        }
            
        //uscita casa
        if(other.CompareTag("Player") && !other.isTrigger && trigger.gameObject.layer == 10){
            if(interactable.pendant_trovato == true && interactable.lettera_sfratto_trovata == true && interactable.mappa_trovata == true){
                Scene_Loader.Load(Scene_Loader.Scene.Esterno_lev1);
                player_storage.initialValue = player_position;
            }
            else{
                Debug.Log("Devi trovare tutti gli oggetti");
                interazione_non_completa.SetActive(true);
                StartCoroutine(interazione_non_completata(interazione_non_completa));
            }
        }
        
        //ingresso stanza
        if(other.CompareTag("Player") && !other.isTrigger && trigger.gameObject.layer == 12){
            
            Scene_Loader.Load(Scene_Loader.Scene.Stanza_sue);
            player_storage.initialValue = player_position;
            
        }

        if(other.CompareTag("Player") && !other.isTrigger && trigger.gameObject.layer == 13){
            if(opened.flag_opened[0] == true){
                Scene_Loader.Load(Scene_Loader.Scene.Casa_sue);
                player_storage.initialValue = player_position;
            }else{
                Debug.Log("Devi aprire il baule");
                interazione_non_completa.SetActive(true);
                StartCoroutine(interazione_non_completata(interazione_non_completa));
            }
        }

        if(other.CompareTag("Player") && !other.isTrigger && trigger.gameObject.layer == 15){
            Scene_Loader.Load(Scene_Loader.Scene.casa_del_cairo);
            player_storage.initialValue = player_position;
        }

        if(other.CompareTag("Player") && !other.isTrigger && trigger.gameObject.layer == 21){ //uscita casa del cairo
            Scene_Loader.Load(Scene_Loader.Scene.Esterno_lev1); 
            player_storage.initialValue = player_position;
        }

        if(other.CompareTag("Player") && !other.isTrigger && trigger.gameObject.layer == 27){ //scena finale
        
            Scene_Loader.Load(Scene_Loader.Scene.Scena_finale); 
        }
    }


        
    IEnumerator interazione_non_completata(GameObject interazione_non_completa){
        yield return new WaitForSeconds(3f);
        interazione_non_completa.SetActive(false);
    }
}

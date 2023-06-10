using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scene_transition : MonoBehaviour
{
    public Vector2 player_position;
    public vector_value player_storage;
    public GameObject trigger; //questo è il trgger a cui è associato  lo script
    private void OnTriggerEnter2D(Collider2D other) {

        //ingresso casa 
        //solo che io voglio vedere i layer e non i tag
        if(other.CompareTag("Player") && !other.isTrigger && trigger.gameObject.layer == 7){
            Scene_Loader.Load(Scene_Loader.Scene.Casa_sue);
            player_storage.initialValue = player_position;
        }
            
        //uscita casa
        if(other.CompareTag("Player") && !other.isTrigger && trigger.gameObject.layer == 10){
            Scene_Loader.Load(Scene_Loader.Scene.Esterno_lev1);
            player_storage.initialValue = player_position;
        }
        
        if(other.CompareTag("Player") && !other.isTrigger && trigger.gameObject.layer == 12){
            Scene_Loader.Load(Scene_Loader.Scene.Stanza_sue);
            player_storage.initialValue = player_position;
        }
    }
}

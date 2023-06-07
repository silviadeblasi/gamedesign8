using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_changescene : MonoBehaviour
{
    public GameObject player; //inserisco il player in modo da salvare la sua posizione
   
    public Vector2 player_pos; //posizione del player
    public vector_value player_storage; //scriptable object per salvare la posizione del player
    private void OnTriggerEnter2D(Collider2D other) {

        //ingresso casa
        if(other.gameObject.layer == 7){
            player_storage.initialValue = player_pos;
            Scene_Loader.Load(Scene_Loader.Scene.Casa_sue);
            
        }

        //uscita casa
        if(other.gameObject.layer == 10){
            Scene_Loader.Load(Scene_Loader.Scene.Esterno_lev1);
        }
    }
}
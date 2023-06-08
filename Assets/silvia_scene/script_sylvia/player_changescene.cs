using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_changescene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {

        //ingresso casa
        if(other.gameObject.layer == 7){
            Scene_Loader.Load(Scene_Loader.Scene.Casa_sue);
            
        }

        //uscita casa
        if(other.gameObject.layer == 10){
            Scene_Loader.Load(Scene_Loader.Scene.Esterno_lev1);
        }
    }
}
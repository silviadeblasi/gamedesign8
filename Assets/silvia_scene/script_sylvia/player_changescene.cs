using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//devo salvare la posizione precedente del player e controllare che se sta uscendo dalla casa non si attivi il trigger dell'ingresso

public class player_changescene : MonoBehaviour
{
    public GameObject player; //inserisco il player in modo da salvare la sua posizione
    private Vector3 player_pos; //salvo la posizione del player
    private void OnTriggerEnter2D(Collider2D other) {

        //casa sue
        if(other.gameObject.layer == 7){
            Scene_Loader.Load(Scene_Loader.Scene.Casa_sue);
        }

        //uscita casa
        if(other.gameObject.layer == 10){
            Scene_Loader.Load(Scene_Loader.Scene.Esterno_lev1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_changescene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {

        //casa sue
        if(other.gameObject.layer == 7){
            Scene_Loader.Load(Scene_Loader.Scene.Casa_sue);
        }
    }
}

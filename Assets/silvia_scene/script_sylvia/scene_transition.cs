using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scene_transition : MonoBehaviour
{
    public Vector2 player_position;
    public vector_value player_storage;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            player_storage.initialValue = player_position;
        }
    }
}

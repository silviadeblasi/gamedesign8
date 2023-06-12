using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint : MonoBehaviour
{
    //quando player entra nel trigger salvo la coordinata del checkpoint
    public vector_value_scene checkpoint_position;
    public GameObject communication_checkpoint;
    private GameObject cloneDialogue;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            cloneDialogue =(GameObject)GameObject.Instantiate(communication_checkpoint, transform.position, Quaternion.identity); //hai trovato il canvas e questo 
            Destroy(cloneDialogue, 2f);
            checkpoint_position.initialValue = this.transform.position;
            checkpoint_position.Scenename = SceneManager.GetActiveScene().name;
        }
    }
}

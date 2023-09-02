using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint : MonoBehaviour
{
    //quando player entra nel trigger salvo la coordinata del checkpoint
    public vector_value_scene checkpoint_position;
    [SerializeField] private GameObject communication_checkpoint;
    private GameObject cloneDialogue;
    public BoxCollider2D _point;
    private void Start() {
        
    }
    // devo fare due trigger diversi per i due check point diversi 
    // il primo fuori dalla casa non è visibilie e quindi non deve uscire avviso hai trovato un checkpoint ma solo salvare la posizione
    // mentre per il secondo deve comparire il messaggio hai trovato un checkpoint e salvare la posizione
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger && _point.isTrigger == true){
            //cloneDialogue =(GameObject)GameObject.Instantiate(communication_checkpoint, transform.position, Quaternion.identity); //hai trovato il canvas e questo 
            //Destroy(cloneDialogue, 2f);
            checkpoint_position.initialValue = this.transform.position;
            checkpoint_position.Scenename = SceneManager.GetActiveScene().name;
            _point.isTrigger = false;
        }
    }
}

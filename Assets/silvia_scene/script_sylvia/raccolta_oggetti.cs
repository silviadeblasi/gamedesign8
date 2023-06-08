using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raccolta_oggetti : MonoBehaviour
{
    [SerializeField] private GameObject oggetto_raccolto;
    private GameObject dialogueBoxClone;
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.layer == 6){

            Destroy(other.gameObject);
            Debug.Log("Oggetto raccolto");
            dialogueBoxClone = (GameObject)GameObject.Instantiate(oggetto_raccolto, transform.position, Quaternion.identity);
            Destroy(dialogueBoxClone, 4f);
        }
    }
}

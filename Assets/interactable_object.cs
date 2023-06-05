using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable_object : MonoBehaviour
{
    [SerializeField] private GameObject Canvas_tomba;

    private GameObject dialogueBoxClone;
    public GameObject player; 

    //attenzione è ontrigger se voglio chiudere il cavas devo usare ontriggerexit/stay e non oncollisionexit/stay
    //blocca il player
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.layer == 8){ //creo un layer per la visione dei canvas relativi a questo script (layer 8)
            dialogueBoxClone = (GameObject)GameObject.Instantiate(Canvas_tomba, transform.position, Quaternion.identity);
        }
        player.GetComponent<PlayerMovement>().enabled = false;
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
                Destroy(dialogueBoxClone, 0.5f);
                player.GetComponent<PlayerMovement>().enabled = true;
            }
    }
}

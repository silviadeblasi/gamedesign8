using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable_object : MonoBehaviour
{
    [SerializeField] private GameObject Canvas_tomba;
    [SerializeField] private GameObject Canvas_perchiusura; //per ricordare all'utente che premendo Z chiude il canvas

    private GameObject dialogueBoxClone;
    private GameObject dialogueBoxClone2; //per ricordare all'utente che premendo Z chiude il canvas
    public GameObject player; 
    private Animator animator;
    private bool canvas_already_spawned = false;
    //attenzione è ontrigger se voglio chiudere il cavas devo usare ontriggerexit/stay e non oncollisionexit/stay
    //blocca il player
    void Start(){
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other) {

        if(other.gameObject.layer == 8){ //creo un layer per la visione dei canvas relativi a questo script (layer 8)
            if(Input.GetKeyDown(KeyCode.X)){
                if (canvas_already_spawned == false)
                {
                   dialogueBoxClone = (GameObject)GameObject.Instantiate(Canvas_tomba, transform.position, Quaternion.identity);
                   player.GetComponent<PlayerMovement>().enabled = false;
                    animator.SetBool("moving", false);
                    canvas_already_spawned = true;
                }
                if (canvas_already_spawned == true)
                {
                    dialogueBoxClone2 = (GameObject)GameObject.Instantiate(Canvas_perchiusura, transform.position, Quaternion.identity);
                    Destroy(dialogueBoxClone2, 3f);
                }
            }   
           /* if(Input.GetKeyDown(KeyCode.Z)){
                Destroy(dialogueBoxClone, 0.5f);
                player.GetComponent<PlayerMovement>().enabled = true;
            }*/
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("openable") && this.gameObject.CompareTag("Player"))
        {
            
            //il canvas c'è appena inzio il gioco e non appena entro nel trigger
            other.GetComponent<openable>().Open();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
                Destroy(dialogueBoxClone, 0.5f);
                player.GetComponent<PlayerMovement>().enabled = true;
                canvas_already_spawned = false;
            }
    }
}

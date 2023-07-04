using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable_object : MonoBehaviour
{
    [SerializeField] private GameObject Canvas_tomba;
    [SerializeField] private GameObject Canvas_perchiusura; //per ricordare all'utente che premendo Z chiude il canvas

    //private GameObject dialogueBoxClone;
    //private GameObject dialogueBoxClone2; //per ricordare all'utente che premendo Z chiude il canvas
    public GameObject player; 
    public GameObject[] canvas_trama;
    public GameObject Canvas_per_chiusura;
    public SoundManager soundManager;
    private Animator animator;
    public bool pendant_trovato = false;
    public bool lettera_sfratto_trovata = false;
    public bool mappa_trovata = false;  
    //private bool canvas_already_spawned = false;
    //attenzione è ontrigger se voglio chiudere il cavas devo usare ontriggerexit/stay e non oncollisionexit/stay
    //blocca il player
    void Start(){
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other) {

        if(other.gameObject.layer == 8){ //creo un layer per la visione dei canvas relativi a questo script (layer 8)
            GameObject canvas_tomba = FindOggetti(canvas_trama, "Canvas_tomba");

            if(Input.GetKeyDown(KeyCode.X)){
                canvas_tomba.SetActive(true);
                Canvas_per_chiusura.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
                animator.SetBool("moving", false);
            }
            if(Input.GetKeyDown(KeyCode.Z)){
                canvas_tomba.SetActive(false);
                Canvas_per_chiusura.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = true;
                animator.SetBool("moving", true);
            }
        }

        //casa sue : pendant madre vicino cadavere
        if(other.gameObject.layer == 16){ 
            GameObject canvas = FindOggetti(canvas_trama, "Canvas_pendant_madre");
            Debug.Log("layer 16");
            if(Input.GetKeyDown(KeyCode.X)){
                soundManager.PlaySoundEffect("Amuleto", 0.6f);
                canvas.SetActive(true);
                Canvas_per_chiusura.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
                animator.SetBool("moving", false);
            }

            if(Input.GetKeyDown(KeyCode.Z)){
                soundManager.PlaySoundEffect("Amuleto", 0.6f);
                canvas.SetActive(false);
                Canvas_per_chiusura.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = true;
                animator.SetBool("moving", true);
                pendant_trovato = true;
            }
        }

        //casa sue : lettera sfratto vicino scale
        if(other.gameObject.layer == 18){ 
            GameObject canvas = FindOggetti(canvas_trama, "Canvas_lettera_sfratto");

            if(Input.GetKeyDown(KeyCode.X)){
                soundManager.PlaySoundEffect("CartaOggetto", 0.6f);
                canvas.SetActive(true);
                Canvas_per_chiusura.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
                animator.SetBool("moving", false);
            }

            if(Input.GetKeyDown(KeyCode.Z)){
                soundManager.PlaySoundEffect("CartaOggetto", 0.6f);
                canvas.SetActive(false);
                Canvas_per_chiusura.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = true;
                animator.SetBool("moving", true);
                lettera_sfratto_trovata = true;
            }
        }

        //casa sue : mappa vicino libreria
        if(other.gameObject.layer == 17){ 
            GameObject canvas = FindOggetti(canvas_trama, "Canvas_mappa");

            if(Input.GetKeyDown(KeyCode.X)){
                soundManager.PlaySoundEffect("AperturaMappa", 0.6f);
                canvas.SetActive(true);
                Canvas_per_chiusura.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
                animator.SetBool("moving", false);
            }
            if(Input.GetKeyDown(KeyCode.Z)){
                soundManager.PlaySoundEffect("AperturaMappa", 0.6f);
                canvas.SetActive(false);
                Canvas_per_chiusura.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = true;
                animator.SetBool("moving", true);
                mappa_trovata = true;
            }
        }
    
    }

    private GameObject FindOggetti(GameObject[] oggetti, string oggetto_name){
        foreach (GameObject oggetto in oggetti)
        {
            if(oggetto.name == oggetto_name){
                return oggetto;
            }
        }
        return null;
    }

}

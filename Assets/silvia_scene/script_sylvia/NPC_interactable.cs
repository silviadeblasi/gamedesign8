using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_interactable : MonoBehaviour
{
    private Animator anim;
    public DialoghiUIManager dialoghiUIManager; //cerco i dialoghi e li faccio comparire
    public GameObject player;
    public GameObject veggente;
    private bool fine1 = false;
    private bool fine2 = false;
    private bool fine3 = false;
    private bool fine4 = false;
    private bool fine5 = false;


    private void Start() {

        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.gameObject.layer == 19){ // veggente
            if(Input.GetKeyDown(KeyCode.X)){
                veggente.GetComponent<BoundedNPC>().enabled = false;
                player.GetComponent<PlayerMovement>().enabled = false;
                //anim.SetBool("interact", true);
                dialoghiUIManager.StartDialoghi("dialogue_veggente_1"); //i bet you are looking for...
            }
            if(dialoghiUIManager.FineDialogo("dialogue_veggente_1") == true && fine1 == false){
                dialoghiUIManager.StartDialoghi("dialogo_sueveggente_1"); //and how do you know
                fine1 = true;
            }
            if(dialoghiUIManager.FineDialogo("dialogo_sueveggente_1") == true && fine2 == false){
                fine2 = true;
                dialoghiUIManager.StartDialoghi("dialogue_veggente_2"); //so qualcosa sul tuo futuro vuoi sapere?
            }
            if(dialoghiUIManager.FineDialogo("dialogue_veggente_2") == true && fine3 == false){
                fine3 = true;
                dialoghiUIManager.StartDialoghi("dialogo_sueveggente_2"); //sto ascoltando
            }
            if(dialoghiUIManager.FineDialogo("dialogo_sueveggente_2") == true && fine4 == false){
                fine4 = true;
                dialoghiUIManager.StartDialoghi("dialogue_veggente_3"); //dice qualcosa sul tuo futuro
            }
            if(dialoghiUIManager.FineDialogo("dialogue_veggente_3") == true && fine5 == false){
                fine5 = true;
                dialoghiUIManager.StartDialoghi("dialogo_sueveggente_3"); //CHE VUOL DIREE
                player.GetComponent<PlayerMovement>().enabled = true;
                veggente.GetComponent<BoundedNPC>().enabled = true;
            }

        }
    }
    /*public void Interact(bool done){
        Debug.Log("interact");

    }*/
   
}

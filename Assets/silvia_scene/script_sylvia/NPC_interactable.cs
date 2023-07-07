using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_interactable : MonoBehaviour
{
    private Animator anim;
    private Animator anim_veggente;
    private Animator anim_ubriacone;
    public DialoghiUIManager dialoghiUIManager; //cerco i dialoghi e li faccio comparire
    public GameObject player;
    public Rigidbody2D rb;
    public GameObject veggente;
    public GameObject ubriacone;
    private Rigidbody2D rb_veggente;
    private Rigidbody2D rb_ubriacone;
    private bool fine1 = false;
    private bool fine2 = false;
    private bool fine3 = false;
    private bool fine4 = false;
    private bool fine5 = false;
    private bool fine6 = false;
    private bool fine7 = false;
    private bool fine8 = false;


    private void Start() {

        anim = GetComponent<Animator>();
        anim_veggente = veggente.GetComponent<Animator>();
        anim_ubriacone = ubriacone.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb_veggente = veggente.GetComponent<Rigidbody2D>();
        rb_ubriacone = ubriacone.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.gameObject.layer == 19){ // veggente
        
            if(Input.GetKeyDown(KeyCode.X)){
                fine1 = false;
                fine2 = false;
                fine3 = false;
                fine4 = false;
                fine5 = false;
                Vector3 dir = veggente.GetComponent<BoundedNPC>().directionVector;
                anim_veggente.SetBool("interact", true);
                anim_veggente.SetFloat("moveX", dir.x);
                anim_veggente.SetFloat("moveY", dir.y);
                rb_veggente.constraints = RigidbodyConstraints2D.FreezeAll;
                veggente.GetComponent<BoundedNPC>().enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                player.GetComponent<PlayerMovement>().enabled = false;
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
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb_veggente.constraints = RigidbodyConstraints2D.None;
                rb_veggente.constraints = RigidbodyConstraints2D.FreezeRotation;
                anim_veggente.SetBool("interact", false);
                veggente.GetComponent<BoundedNPC>().enabled = true;
            }

        }

        if(other.gameObject.layer == 20){ //ubriacone
        
            if(Input.GetKeyDown(KeyCode.X)){
                fine1 = false;
                fine2 = false;
                fine3 = false;
                fine4 = false;
                fine5 = false;
                Vector3 dir = ubriacone.GetComponent<BoundedNPC>().directionVector;
                anim_ubriacone.SetBool("interact", true);
                anim_ubriacone.SetFloat("moveX", dir.x);
                anim_ubriacone.SetFloat("moveY", dir.y);
                rb_ubriacone.constraints = RigidbodyConstraints2D.FreezeAll;
                ubriacone.GetComponent<BoundedNPC>().enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                player.GetComponent<PlayerMovement>().enabled = false;
                dialoghiUIManager.StartDialoghi("dialogue_drunk_1"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogue_drunk_1") == true && fine1 == false){
                dialoghiUIManager.StartDialoghi("dialogo_suedrunk_1"); 
                fine1 = true;
            }
            if(dialoghiUIManager.FineDialogo("dialogo_suedrunk_1") == true && fine2 == false){
                fine2 = true;
                dialoghiUIManager.StartDialoghi("dialogue_drunk_2"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogue_drunk_2") == true && fine3 == false){
                fine3 = true;
                dialoghiUIManager.StartDialoghi("dialogo_suedrunk_2"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogo_suedrunke_2") == true && fine4 == false){
                fine4 = true;
                dialoghiUIManager.StartDialoghi("dialogue_drunk_3"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogue_drunk_3") == true && fine5 == false){
                fine5 = true;
                dialoghiUIManager.StartDialoghi("dialogo_suedrunk_4");
            }
            if(dialoghiUIManager.FineDialogo("dialogo_suedrunke_4") == true && fine6 == false){
                fine6 = true;
                dialoghiUIManager.StartDialoghi("dialogue_drunk_5"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogue_drunk_5") == true && fine7 == false){
                fine7 = true;
                dialoghiUIManager.StartDialoghi("dialogo_suedrunk_5"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogo_suedrunk_5") == true && fine8 == false){
                fine8 = true;
                dialoghiUIManager.StartDialoghi("dialogo_suedrunk_3"); 
                player.GetComponent<PlayerMovement>().enabled = true;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb_ubriacone.constraints = RigidbodyConstraints2D.None;
                rb_ubriacone.constraints = RigidbodyConstraints2D.FreezeRotation;
                anim_ubriacone.SetBool("interact", false);
                ubriacone.GetComponent<BoundedNPC>().enabled = true;
            }

        }

        /*if(other.gameObject.layer == 20){ //villager pistola
        
            if(Input.GetKeyDown(KeyCode.X)){
                fine1 = false;
                fine2 = false;
                fine3 = false;
                fine4 = false;
                fine5 = false;
                Vector3 dir = ubriacone.GetComponent<BoundedNPC>().directionVector;
                anim2.SetBool("interact", true);
                anim2.SetFloat("moveX", dir.x);
                anim2.SetFloat("moveY", dir.y);
                rb_ubriacone.constraints = RigidbodyConstraints2D.FreezeAll;
                ubriacone.GetComponent<BoundedNPC>().enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                player.GetComponent<PlayerMovement>().enabled = false;
                dialoghiUIManager.StartDialoghi("dialogue_drunk_1"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogue_drunk_1") == true && fine1 == false){
                dialoghiUIManager.StartDialoghi("dialogo_suedrunk_1"); 
                fine1 = true;
            }
            if(dialoghiUIManager.FineDialogo("dialogo_suedrunk_1") == true && fine2 == false){
                fine2 = true;
                dialoghiUIManager.StartDialoghi("dialogue_drunk_2"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogue_drunk_2") == true && fine3 == false){
                fine3 = true;
                dialoghiUIManager.StartDialoghi("dialogo_suedrunk_2"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogo_suedrunke_2") == true && fine4 == false){
                fine4 = true;
                dialoghiUIManager.StartDialoghi("dialogue_drunk_3"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogue_drunk_3") == true && fine5 == false){
                fine5 = true;
                dialoghiUIManager.StartDialoghi("dialogo_suedrunk_4");
            }
            if(dialoghiUIManager.FineDialogo("dialogo_suedrunke_4") == true && fine6 == false){
                fine6 = true;
                dialoghiUIManager.StartDialoghi("dialogue_drunk_5"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogue_drunk_5") == true && fine7 == false){
                fine7 = true;
                dialoghiUIManager.StartDialoghi("dialogo_suedrunk_5"); 
            }
            if(dialoghiUIManager.FineDialogo("dialogo_suedrunk_5") == true && fine8 == false){
                fine8 = true;
                dialoghiUIManager.StartDialoghi("dialogo_suedrunk_3"); 
                player.GetComponent<PlayerMovement>().enabled = true;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb_ubriacone.constraints = RigidbodyConstraints2D.None;
                rb_ubriacone.constraints = RigidbodyConstraints2D.FreezeRotation;
                anim2.SetBool("interact", false);
                ubriacone.GetComponent<BoundedNPC>().enabled = true;
            }

        }*/


    }
   
}

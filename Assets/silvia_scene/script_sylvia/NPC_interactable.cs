using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_interactable : MonoBehaviour
{
    private Animator anim;
    private Animator anim_veggente;
    private Animator anim_ubriacone;
    private Animator anim_village_pistola;
    public DialoghiUIManager dialoghiUIManager; //cerco i dialoghi e li faccio comparire
    public GameObject player;
    public Rigidbody2D rb_player;
    public GameObject veggente;
    public GameObject ubriacone;
    public GameObject villager_pistola;
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
    private bool fine9 = false;
    private bool fine10 = false;
    private bool fine11 = false;


    private void Start() {

        anim = GetComponent<Animator>();
        anim_veggente = veggente.GetComponent<Animator>();
        anim_ubriacone = ubriacone.GetComponent<Animator>();
        rb_player = GetComponent<Rigidbody2D>();
        rb_veggente = veggente.GetComponent<Rigidbody2D>();
        rb_ubriacone = ubriacone.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.gameObject.layer == 19){ // veggente
            Vector3 dir = veggente.GetComponent<BoundedNPC>().directionVector;
            anim_veggente.SetBool("interact", true);
            anim_veggente.SetFloat("moveX", dir.x);
            anim_veggente.SetFloat("moveY", dir.y);
            rb_veggente.constraints = RigidbodyConstraints2D.FreezeAll;
            veggente.GetComponent<BoundedNPC>().enabled = false;

            if(Input.GetKeyDown(KeyCode.X)){
                fine1 = false;
                fine2 = false;
                fine3 = false;
                fine4 = false;
                fine5 = false;
                fine6 = false;
                fine7 = false;
                fine8 = false;
                rb_player.constraints = RigidbodyConstraints2D.FreezeAll;
                player.GetComponent<PlayerMovement>().enabled = false;
                dialoghiUIManager.StartDialoghi("dg_sh_1"); //i bet you are looking for...
            }

            if(dialoghiUIManager.FineDialogo("dg_sh_1") == true && fine1 == false){
                dialoghiUIManager.StartDialoghi("dg_sh_sue_1"); //and how do you know
                fine1 = true;
            }
            
            if(dialoghiUIManager.FineDialogo("dg_sh_sue_1") == true && fine2 == false){
                fine2 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_2"); //so qualcosa sul tuo futuro vuoi sapere?
            }
                if(dialoghiUIManager.FineDialogo("dg_sh_2") == true && fine3 == false){
                fine3 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_sue_2"); //sto ascoltando
            }
            if(dialoghiUIManager.FineDialogo("dg_sh_sue_2") == true && fine4 == false){
                fine4 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_3"); //dice qualcosa sul tuo futuro
            }
            if(dialoghiUIManager.FineDialogo("dg_sh_3") == true && fine5 == false){
                fine5 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_sue_3");
            }
            if(dialoghiUIManager.FineDialogo("dg_sh_sue_3") == true && fine6 == false){
                fine6 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_4"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_sh_4") == true && fine7 == false){
                fine7 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_sue_4");
            }
            if(dialoghiUIManager.FineDialogo("dg_sh_sue_4") == true && fine8 == false){
                player.GetComponent<PlayerMovement>().enabled = true;
                rb_player.constraints = RigidbodyConstraints2D.None;
                rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            
        }

        if(other.gameObject.layer == 20){ //ubriacone
            Vector3 dir = ubriacone.GetComponent<BoundedNPC>().directionVector;
            anim_ubriacone.SetBool("interact", true);
            anim_ubriacone.SetFloat("moveX", dir.x);
            anim_ubriacone.SetFloat("moveY", dir.y);
            rb_ubriacone.constraints = RigidbodyConstraints2D.FreezeAll;
            ubriacone.GetComponent<BoundedNPC>().enabled = false;

            if(Input.GetKeyDown(KeyCode.X)){
                fine1 = false;
                fine2 = false;
                fine3 = false;
                fine4 = false;
                fine5 = false;
                fine6 = false;
                fine7 = false;
                fine8 = false;
                fine9 = false;
                fine10 = false;
                fine11 = false;
                
                rb_player.constraints = RigidbodyConstraints2D.FreezeAll;
                player.GetComponent<PlayerMovement>().enabled = false;
                dialoghiUIManager.StartDialoghi("dg_dk_1"); 
            }

            if(dialoghiUIManager.FineDialogo("dg_dk_1") == true && fine1 == false){
                dialoghiUIManager.StartDialoghi("dg_dk_sue_1"); 
                fine1 = true;
            }
            if(dialoghiUIManager.FineDialogo("dg_sk_sue_1") == true && fine2 == false){
                fine2 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_2"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_2") == true && fine3 == false){
                fine3 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_sue_2"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_sue_2") == true && fine4 == false){
                fine4 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_3"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_3") == true && fine5 == false){
                fine5 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_sue_3");
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_sue_3") == true && fine6 == false){
                fine6 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_4"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_4") == true && fine7 == false){
                fine7 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_sue_4");
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_sue_4") == true && fine8 == false){
                fine8 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_5"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_5") == true && fine9 == false){
                fine9 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_sue_5");
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_sue_5") == true && fine10 == false){
                fine10 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_6");
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_6") == true && fine11 == false){
                player.GetComponent<PlayerMovement>().enabled = true;
                rb_player.constraints = RigidbodyConstraints2D.None;
                rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

        }

        /*if(other.gameObject.layer == 21){ //villager pistola
        
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

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.layer == 19){ // veggente
            anim_veggente.SetBool("interact", false);
            rb_veggente.constraints = RigidbodyConstraints2D.None;
            rb_veggente.constraints = RigidbodyConstraints2D.FreezeRotation;
            veggente.GetComponent<BoundedNPC>().enabled = true;
        }

        if(other.gameObject.layer == 20){ // ubriacone
            anim_ubriacone.SetBool("interact", false);
            rb_ubriacone.constraints = RigidbodyConstraints2D.None;
            rb_ubriacone.constraints = RigidbodyConstraints2D.FreezeRotation;
            ubriacone.GetComponent<BoundedNPC>().enabled = true;
        }
    }

   
}

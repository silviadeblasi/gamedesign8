using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_interactable : MonoBehaviour
{
    private Animator anim;
    private Animator anim_veggente;
    private Animator anim_ubriacone;
    private Animator anim_villager_1;
    private Animator anim_villager_2;
    public DialoghiUIManager dialoghiUIManager; //cerco i dialoghi e li faccio comparire
    public GameObject player;
    public Rigidbody2D rb_player;
    public GameObject veggente;
    public GameObject ubriacone;
    public GameObject bottiglia_ubriacone;
    public GameObject villager_1;
    public GameObject villager_2;
    private Rigidbody2D rb_veggente;
    private Rigidbody2D rb_ubriacone;
    private Rigidbody2D rb_villager_1;
    private Rigidbody2D rb_villager_2;
    public GameObject villager_3;
    private Rigidbody2D rb_villager_3;
    private Animator anim_villager_3;
    public GameObject canvas_pistola;
    public GameObject pistola;

    //combattimento 5 , pistola con villager
    public Combact_5 comb_5;

    // bool per i dialoghi
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
    private bool solve_problem = false;


    private void Start() {


        anim = GetComponent<Animator>();
        anim_veggente = veggente.GetComponent<Animator>();
        anim_ubriacone = ubriacone.GetComponent<Animator>();
        anim_villager_1 = villager_1.GetComponent<Animator>();
        anim_villager_2 = villager_2.GetComponent<Animator>();
        rb_player = GetComponent<Rigidbody2D>();
        rb_veggente = veggente.GetComponent<Rigidbody2D>();
        rb_ubriacone = ubriacone.GetComponent<Rigidbody2D>();
        rb_villager_1 = villager_1.GetComponent<Rigidbody2D>();
        rb_villager_2 = villager_2.GetComponent<Rigidbody2D>();
        anim_villager_3 = villager_3.GetComponent<Animator>();
        rb_villager_3 = villager_3.GetComponent<Rigidbody2D>();

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
                fine9 = false;
                fine10 = false;
                fine11 = false;
                solve_problem = true;

                rb_player.constraints = RigidbodyConstraints2D.FreezeAll;
                player.GetComponent<PlayerMovement>().enabled = false;
                dialoghiUIManager.StartDialoghi("dg_sh_1"); //i bet you are looking for...
            }

            if(dialoghiUIManager.FineDialogo("dg_sh_1") == true && fine1 == false && solve_problem == true){
                dialoghiUIManager.StartDialoghi("dg_sh_sue_1"); //and how do you know
                fine1 = true;
            }
            
            if(dialoghiUIManager.FineDialogo("dg_sh_sue_1") == true && fine2 == false && solve_problem == true){
                fine2 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_2"); //so qualcosa sul tuo futuro vuoi sapere?
            }
                if(dialoghiUIManager.FineDialogo("dg_sh_2") == true && fine3 == false && solve_problem == true){
                fine3 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_sue_2"); //sto ascoltando
            }
            if(dialoghiUIManager.FineDialogo("dg_sh_sue_2") == true && fine4 == false && solve_problem == true){
                fine4 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_3"); //dice qualcosa sul tuo futuro
            }
            if(dialoghiUIManager.FineDialogo("dg_sh_3") == true && fine5 == false && solve_problem == true){
                fine5 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_sue_3");
            }
            if(dialoghiUIManager.FineDialogo("dg_sh_sue_3") == true && fine6 == false && solve_problem == true){
                fine6 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_4"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_sh_4") == true && fine7 == false && solve_problem == true){
                fine7 = true;
                dialoghiUIManager.StartDialoghi("dg_sh_sue_4");
            }
            if(dialoghiUIManager.FineDialogo("dg_sh_sue_4") == true && fine8 == false && solve_problem == true){
                player.GetComponent<PlayerMovement>().enabled = true;
                rb_player.constraints = RigidbodyConstraints2D.None;
                rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;
                solve_problem = false;
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
                solve_problem = true;
                rb_player.constraints = RigidbodyConstraints2D.FreezeAll;
                player.GetComponent<PlayerMovement>().enabled = false;
                dialoghiUIManager.StartDialoghi("dg_dk_1"); 
            }

            if(dialoghiUIManager.FineDialogo("dg_dk_1") == true && fine1 == false && solve_problem == true){
                dialoghiUIManager.StartDialoghi("dg_dk_sue_1"); 
                fine1 = true;
            }
            if(dialoghiUIManager.FineDialogo("dg_sk_sue_1") == true && fine2 == false && solve_problem == true){
                fine2 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_2"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_2") == true && fine3 == false && solve_problem == true){
                fine3 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_sue_2"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_sue_2") == true && fine4 == false && solve_problem == true){
                fine4 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_3"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_3") == true && fine5 == false && solve_problem == true){
                fine5 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_sue_3");
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_sue_3") == true && fine6 == false && solve_problem == true){
                fine6 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_4"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_4") == true && fine7 == false && solve_problem == true){
                fine7 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_sue_4");
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_sue_4") == true && fine8 == false && solve_problem == true){
                fine8 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_5"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_5") == true && fine9 == false && solve_problem == true){
                fine9 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_sue_5");
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_sue_5") == true && fine10 == false && solve_problem == true){
                fine10 = true;
                dialoghiUIManager.StartDialoghi("dg_dk_6");
            }
            if(dialoghiUIManager.FineDialogo("dg_dk_6") == true && fine11 == false && solve_problem == true){
                player.GetComponent<PlayerMovement>().enabled = true;
                rb_player.constraints = RigidbodyConstraints2D.None;
                rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;
                solve_problem = false;
                bottiglia_ubriacone.SetActive(true);
            }

        }

        if(other.gameObject.layer == 22){ //villager_1
                Vector3 dir = villager_1.GetComponent<BoundedNPC>().directionVector;
                anim_villager_1.SetBool("interact", true);
                anim_villager_1.SetFloat("moveX", dir.x);
                anim_villager_1.SetFloat("moveY", dir.y);
                rb_villager_1.constraints = RigidbodyConstraints2D.FreezeAll;
                villager_1.GetComponent<BoundedNPC>().enabled = false;
        
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
                dialoghiUIManager.StartDialoghi("dg_ct_1"); 
            }
            if(dialoghiUIManager.FineDialogo("dg_ct_1") == true && fine1 == false){ 
                fine1 = true;
                player.GetComponent<PlayerMovement>().enabled = true;
                rb_player.constraints = RigidbodyConstraints2D.None;
                rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

        }

            if(other.gameObject.layer == 23){ //villager_2
                Vector3 dir = villager_1.GetComponent<BoundedNPC>().directionVector;
                anim_villager_2.SetBool("interact", true);
                anim_villager_2.SetFloat("moveX", dir.x);
                anim_villager_2.SetFloat("moveY", dir.y);
                rb_villager_2.constraints = RigidbodyConstraints2D.FreezeAll;
                villager_2.GetComponent<BoundedNPC>().enabled = false;
        
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
                dialoghiUIManager.StartDialoghi("dg_ct_2_1"); 
            }

            if(dialoghiUIManager.FineDialogo("dg_ct_2_1") == true && fine1 == false){ 
                fine1 = true;
                dialoghiUIManager.StartDialoghi("dg_ct_sue_2");
            }
            if(dialoghiUIManager.FineDialogo("dg_ct_sue_2") == true && fine2 == false){
                fine2 = true;
                dialoghiUIManager.StartDialoghi("dg_ct_2_2");
            }
            if(dialoghiUIManager.FineDialogo("dg_ct_2_2") == true && fine3 == false){
                fine3 = true;
                player.GetComponent<PlayerMovement>().enabled = true;
                rb_player.constraints = RigidbodyConstraints2D.None;
                rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
               
        }

        if(other.gameObject.layer == 25){ //villager_3 pistola 
                Vector3 dir = villager_1.GetComponent<BoundedNPC>().directionVector;
                anim_villager_3.SetBool("interact", true);
                anim_villager_3.SetFloat("moveX", dir.x);
                anim_villager_3.SetFloat("moveY", dir.y);
                rb_villager_3.constraints = RigidbodyConstraints2D.FreezeAll;
                villager_3.GetComponent<BoundedNPC>().enabled = false;
        
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

                if(comb_5.fatto_comb_5 == true){
                    dialoghiUIManager.StartDialoghi("dg_ct_comb_5_fatto"); 

                    if(dialoghiUIManager.FineDialogo("dg_ct_comb_5_fatto") == true){
                        canvas_pistola.SetActive(true);
                        StartCoroutine(fine_pistola());
                        pistola.SetActive(true);
                    }
                }
                else{
                    dialoghiUIManager.StartDialoghi("dg_ct_3_1");

                }
            
               
            }
        }


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

        if(other.gameObject.layer == 22){ // villager_1
            anim_villager_1.SetBool("interact", false);
            rb_villager_1.constraints = RigidbodyConstraints2D.None;
            rb_villager_1.constraints = RigidbodyConstraints2D.FreezeRotation;
            villager_1.GetComponent<BoundedNPC>().enabled = true;
        }

        if(other.gameObject.layer == 23){ // villager_2
            anim_villager_2.SetBool("interact", false);
            rb_villager_2.constraints = RigidbodyConstraints2D.None;
            rb_villager_2.constraints = RigidbodyConstraints2D.FreezeRotation;
            villager_2.GetComponent<BoundedNPC>().enabled = true;
        }

        if(other.gameObject.layer == 25){ // villager_3 pistola
            anim_villager_3.SetBool("interact", false);
            rb_villager_3.constraints = RigidbodyConstraints2D.None;
            rb_villager_3.constraints = RigidbodyConstraints2D.FreezeRotation;
            villager_3.GetComponent<BoundedNPC>().enabled = true;
        }
    }

    IEnumerator fine_pistola(){
        yield return new WaitForSeconds(3f);
        canvas_pistola.SetActive(false);
    }

   
}

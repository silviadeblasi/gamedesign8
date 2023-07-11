using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combact_3: Combact{
    public GameObject player;
    private Animator anim;
    public DialoghiUIManager dialoghiManager;
    private GameObject dialogueBoxClone;
    public GameObject Dialogo_primo_combattimento;
    public GameObject Dialogo_fine_primo_combattimento;
    public GameObject Combattimento3;
    public GameObject third_battle;
    public GameObject Muretto_final;
    public GameObject Fire_intorno;
    private bool dialogo_iniziale = false;
    private bool fine_dialogo_inizio_combattimento = false;
    private bool dead_1 = false;
    private bool dead_2 = false;
    private bool dead_3 = false;
    private bool dead_4 = false;
    private bool dead_5 = false;
    private bool fatto_tutti_comb = false;

    private void Start() {
        anim = player.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            combact._inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            combact._inTrigger = false;
        }
    }
    private void Update() {

        if(CombactManager.combactManager.FirstCombactDone == true){
            
            

            if(combact._inTrigger){

            CombactManager.combactManager.CombactRequest(this);
               if(CombactManager.combactManager.currentCombact.id == 2){
                third_battle.SetActive(true);
                Fire_intorno.SetActive(true);
            if(CombactManager.combactManager.currentCombact.progress == GeneralCombact.CombactProgress.ACCEPTED){
            //se la current quest è il primo combattimento abilita script dei nemici del primo blocco 
                Combattimento3.transform.Find("enemies (3.1)").gameObject.GetComponent<EnemyController>().enabled = true;
                Combattimento3.transform.Find("enemies (3.2)").gameObject.GetComponent<EnemyController>().enabled = true;
                Combattimento3.transform.Find("enemies (3.3)").gameObject.GetComponent<EnemyController>().enabled = true;
                Combattimento3.transform.Find("enemies (3.4)").gameObject.GetComponent<EnemyController>().enabled = true;
                Combattimento3.transform.Find("enemies (3.5)").gameObject.GetComponent<EnemyController>().enabled = true;

            }

           if(Combattimento3.transform.Find("enemies (3.1)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_1 == false){
               CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_1 = true;
           }
           if(Combattimento3.transform.Find("enemies (3.2)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_2 == false){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_2 = true;

           }
            if(Combattimento3.transform.Find("enemies (3.3)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_3 == false){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_3 = true;
            }
            if(Combattimento3.transform.Find("enemies (3.4)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_4 == false){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_4 = true;
            }
            if(Combattimento3.transform.Find("enemies (3.5)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_5 == false){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_5 = true;
                 
            }


           if(CombactManager.combactManager.currentCombact.CombactObjectiveCount == CombactManager.combactManager.currentCombact.CombactObjectiveRequirement){
                CombactManager.combactManager.currentCombact.progress = GeneralCombact.CombactProgress.DONE;
                third_battle.SetActive(false);
                Fire_intorno.SetActive(false);
                }

            if(CombactManager.combactManager.currentCombact.progress == GeneralCombact.CombactProgress.DONE){
                CombactManager.combactManager.FirstCombactDone = true; // ho fatto il primo combattimento quindi ora posso fare gli altri 
                
            }


               } else {
                    third_battle.SetActive(false);
                    if(CombactManager.combactManager.CheckEverythingDone() && fatto_tutti_comb == false){
                        dialoghiManager.StartDialoghi("Dialogo_allcobact_done");
                        Muretto_final.SetActive(false);
                        fatto_tutti_comb = true;
                    }
               }
               
            //player.GetComponent<PlayerMovement>().enabled = false;
            //anim.SetBool("isWalking", false); //??
            /*if(dialogo_iniziale == false)
                dialogueBoxClone = (GameObject) GameObject.Instantiate(Dialogo_primo_combattimento, transform.position, Quaternion.identity);
                dialogo_iniziale = true;
            if(fine_dialogo_inizio_combattimento == false && (((dialogueBoxClone.transform.Find("Canvas_dialogue")?.gameObject).transform.Find("dialogueBox")?.gameObject).GetComponent<dialogue_script>()).fine_dialogo == true){
                fine_dialogo_inizio_combattimento = true;
                Debug.Log("combact 1");
                player.GetComponent<PlayerMovement>().enabled = true;
                //inizia il combattimento
            }*/
           //CombactManager.combactManager.CombactRequest(this);//assegna come corrente il combattimento 1


        }

        } // devo fare un else if che se non ha fatto il primo combattimento non posso fare gli altri 
        SetCombact(); //setto il combattimento come fatto!!

    }
    
}


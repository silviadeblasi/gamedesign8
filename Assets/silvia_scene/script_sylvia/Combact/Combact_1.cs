using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combact_1 : Combact{
    public GameObject player;
    private Animator anim;
    public DialoghiUIManager dialoghiManager;
    private GameObject dialogueBoxClone;
    public GameObject Dialogo_primo_combattimento;
    public GameObject first_battle;
    public GameObject Fire_intorno;
    public GameObject Combattimento1;
    public GameObject comb_3;
    public GameObject comb_2;
    public GameObject comb_4;
    public GameObject comb_5;
    private bool dialogo_iniziale = false;
    private bool fine_dialogo_inizio_combattimento = false;
    private bool dead_1 = false;
    private bool dead_2 = false;
    private bool dead_3 = false;
    private bool fine_combattimento =false ;
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

        
        if(combact._inTrigger){
            CombactManager.combactManager.CombactRequest(this);

            if(CombactManager.combactManager.currentCombact.id == 0){
                Fire_intorno.SetActive(true);
                first_battle.SetActive(true);
                comb_2.SetActive(false);
                comb_3.SetActive(false);
                comb_4.SetActive(false);
                comb_5.SetActive(false);
                
                if(CombactManager.combactManager.currentCombact.progress == GeneralCombact.CombactProgress.ACCEPTED){
                //se la current quest è il primo combattimento abilita script dei nemici del primo blocco 
                Combattimento1.transform.Find("enemies (1.1)").gameObject.GetComponent<EnemyController1>().enabled = true;
                Combattimento1.transform.Find("enemies (1.2)").gameObject.GetComponent<EnemyController1>().enabled = true;
                Combattimento1.transform.Find("enemies (1.3)").gameObject.GetComponent<EnemyController1>().enabled = true;
            }

           if(Combattimento1.transform.Find("enemies (1.1)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_1 == false){
               CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_1 = true;
                Debug.Log("morto 1");
           }
           if(Combattimento1.transform.Find("enemies (1.2)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_2 == false){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_2 = true;
                Debug.Log("morto 2");
            }
            if(Combattimento1.transform.Find("enemies (1.3)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_3 == false){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_3 = true;
                Debug.Log("morto 3");
            }

           if(CombactManager.combactManager.currentCombact.CombactObjectiveCount == CombactManager.combactManager.currentCombact.CombactObjectiveRequirement){
                CombactManager.combactManager.currentCombact.progress = GeneralCombact.CombactProgress.DONE;
                first_battle.SetActive(false);
                Fire_intorno.SetActive(false);

            if(fine_combattimento == false && CombactManager.combactManager.currentCombact.CombactObjectiveCount != 0 ){
                    dialoghiManager.StartDialoghi("dg_sue_fine_combattimento1"); 
                    fine_combattimento = true;
                }
           }
           
            
        

            if(CombactManager.combactManager.currentCombact.progress == GeneralCombact.CombactProgress.DONE){
                Debug.Log("fatto");
                CombactManager.combactManager.FirstCombactDone = true; // ho fatto il primo combattimento quindi ora posso fare gli altri 
                comb_2.SetActive(true);
                comb_3.SetActive(true);
                comb_4.SetActive(true);
                comb_5.SetActive(true);

            }

            }else{
                first_battle.SetActive(false);
            }
        
            //
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
           //CombactManager.combactManager.CombactRequest(this);//assegna come corrente il combattimento 1ù


        }

        SetCombact(); //setto il combattimento come fatto!!

    }
    
}


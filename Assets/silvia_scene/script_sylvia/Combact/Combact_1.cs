using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combact_1 : Combact{
    public GameObject player;
    private Animator anim;
    private GameObject dialogueBoxClone;
    public GameObject Dialogo_primo_combattimento;
    public GameObject Dialogo_fine_primo_combattimento;
    public GameObject Combattimento1;
    private bool dialogo_iniziale = false;
    private bool fine_dialogo_inizio_combattimento = false;

    private void Start() {
        anim = player.GetComponent<Animator>();
    }
    private void Update() {
        if(combact._inTrigger){
            
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
           CombactManager.combactManager.CombactRequest(this);//assegna come corrente il combattimento 1ù

            //se la current quest è il primo combattimento abilita script dei nemici del primo blocco 
           if(CombactManager.combactManager.currentCombact.id == 0){
                Combattimento1.transform.Find("enemies (1.1)").gameObject.GetComponent<EnemyController1>().enabled = true;
               Combattimento1.transform.Find("enemies (1.2)").gameObject.GetComponent<EnemyController1>().enabled = true;
               Combattimento1.transform.Find("enemies (1.3)").gameObject.GetComponent<EnemyController1>().enabled = true;
           }else{
                Combattimento1.transform.Find("enemies (1.1)").gameObject.GetComponent<EnemyController1>().enabled = false;
                Combattimento1.transform.Find("enemies (1.2)").gameObject.GetComponent<EnemyController1>().enabled = false;
                Combattimento1.transform.Find("enemies (1.3)").gameObject.GetComponent<EnemyController1>().enabled = false;
           }

           if(Combattimento1.transform.Find("enemies (1.1)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 ){
               CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
           }
           if(Combattimento1.transform.Find("enemies (1.2)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
           }
            if(Combattimento1.transform.Find("enemies (1.3)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
            }

           if(CombactManager.combactManager.currentCombact.CombactObjectiveCount == CombactManager.combactManager.currentCombact.CombactObjectiveRequirement){
                CombactManager.combactManager.currentCombact.progress = GeneralCombact.CombactProgress.COMPLETE;
           }

           if(CombactManager.combactManager.currentCombact.progress == GeneralCombact.CombactProgress.COMPLETE){
                //dialogueBoxClone = (GameObject) GameObject.Instantiate(Dialogo_fine_primo_combattimento, transform.position, Quaternion.identity);
                CombactManager.combactManager.currentCombact.progress = GeneralCombact.CombactProgress.DONE;
           }

            if(CombactManager.combactManager.currentCombact.progress == GeneralCombact.CombactProgress.DONE){
                CombactManager.combactManager.FirstCombactDone = true; // ho fatto il primo combattimento quindi ora posso fare gli altri 
            }

        }

        SetCombact(); //setto il combattimento come fatto!!

    }
}

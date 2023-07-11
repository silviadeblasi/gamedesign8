using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinalCombact : MonoBehaviour {

    public DialoghiUIManager dialoghiManager;
    public GameObject player;
    private Animator anim_player;

    private void Start() {
        anim_player = player.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            player.GetComponent<PlayerMovement>().enabled = false;
            anim_player.SetBool("moving",fasle);
            dialoghiManager.StartDialoghi("dialogo_boss_finale");
        }
    }

    private void Update() {
<<<<<<< Updated upstream
        if(dialoghiManager.FineDialogo("dialogo_boss_finale")){ //dialogo iniziale finito puo iniziare ultimo combattimento 
=======

        if(CombactManager.combactManager.FirstCombactDone == true){
            
            CombactManager.combactManager.CombactRequest(this);

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
           //CombactManager.combactManager.CombactRequest(this);//assegna come corrente il combattimento 1
            if(CombactManager.combactManager.currentCombact.progress == GeneralCombact.CombactProgress.ACCEPTED){
            //se la current quest è il primo combattimento abilita script dei nemici del primo blocco 
                Combattimento2.transform.Find("enemies (2.1)").gameObject.GetComponent<EnemyController>().enabled = true;
                Combattimento2.transform.Find("enemies (2.2)").gameObject.GetComponent<EnemyController>().enabled = true;
                Combattimento2.transform.Find("enemies (2.3)").gameObject.GetComponent<EnemyController>().enabled = true;
                Combattimento2.transform.Find("enemies (2.4)").gameObject.GetComponent<EnemyController>().enabled = true;
                Combattimento2.transform.Find("enemies (2.5)").gameObject.GetComponent<EnemyController>().enabled = true;

            }

           if(Combattimento2.transform.Find("enemies (2.1)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_1 == false){
               CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_1 = true;
           }
           if(Combattimento2.transform.Find("enemies (2.2)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_2 == false){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_2 = true;

           }
            if(Combattimento2.transform.Find("enemies (2.3)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_3 == false){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_3 = true;
            }
            if(Combattimento2.transform.Find("enemies (2.4)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_4 == false){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_4 = true;
            }
            if(Combattimento2.transform.Find("enemies (2.5)").gameObject.GetComponent<EnemyHealth>().currentHelath <= 0 && dead_5 == false){
                CombactManager.combactManager.currentCombact.CombactObjectiveCount ++; //ho ucciso un nemico e sommo 1 al contatore;
                dead_5 = true;
            }


           if(CombactManager.combactManager.currentCombact.CombactObjectiveCount == CombactManager.combactManager.currentCombact.CombactObjectiveRequirement){
                CombactManager.combactManager.currentCombact.progress = GeneralCombact.CombactProgress.DONE;
           }

           /*if(CombactManager.combactManager.currentCombact.progress == GeneralCombact.CombactProgress.COMPLETE){
                //dialogueBoxClone = (GameObject) GameObject.Instantiate(Dialogo_fine_primo_combattimento, transform.position, Quaternion.identity);
                CombactManager.combactManager.currentCombact.progress = GeneralCombact.CombactProgress.DONE; //dopo il dialogo
           }*/

            if(CombactManager.combactManager.currentCombact.progress == GeneralCombact.CombactProgress.DONE){
                CombactManager.combactManager.FirstCombactDone = true; // ho fatto il primo combattimento quindi ora posso fare gli altri 
                
            }
>>>>>>> Stashed changes

        }
    }
}
    


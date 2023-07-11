using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCombact : MonoBehaviour {

    public DialoghiUIManager dialoghiManager;
    public GameObject player;
    private Animator anim_player;
    public GameObject boss;
    public GameObject fire_battle;
    public GameObject fire_ending;
    private bool starting = true;
    public GameObject tirgger_final_scene;

    private void Start() {
        anim_player = player.GetComponent<Animator>();
    }
    /*private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" ){
            combact._inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            combact._inTrigger = false;
        }
    }*/
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player" ){
            if(starting == true){
                dialoghiManager.StartDialoghi("dialogo_boss_finale");
                fire_battle.SetActive(true);
                starting = false;
            }
        }
    }

    private void Update(){
    
        if(boss.GetComponent<BossHealth>().currentHealth <= 0){
            fire_battle.SetActive(false);
            fire_ending.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            anim_player.SetBool("moving",false);
            dialoghiManager.StartDialoghi("dialogo_vittoria");
            if(dialoghiManager.FineDialogo("dialogo_vittoria")){
                player.GetComponent<PlayerMovement>().enabled = true;
                anim_player.SetBool("moving",true);
                tirgger_final_scene.SetActive(true);
            }
        }
        
    }
    /*private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log()
        if(other.CompareTag("Player") && !other.isTrigger){
            player.GetComponent<PlayerMovement>().enabled = false;
            anim_player.SetBool("moving",false);
            fire_battle.SetActive(true);
            //dialoghiManager.StartDialoghi("dialogo_boss_finale");
        }
    }*/

}
    


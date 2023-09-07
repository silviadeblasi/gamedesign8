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
    public bool end = false;
    public GameObject tirgger_final_scene;
    public GameObject final_combact; //canvas con il testo: final combact
    [SerializeField] private GameObject comb_1;
    [SerializeField] private GameObject comb_2;
    [SerializeField] private GameObject comb_3;
    [SerializeField] private GameObject comb_4;
    [SerializeField] private GameObject comb_5;
    public bool finito_livello_cairo = false; 
    public vector_value player_storage;

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
            //if(comb_2.fatto_tutti_comb_2 == true || comb_3.fatto_tutti_comb_3 == true || comb_4.fatto_tutti_comb_4 == true || comb_5.fatto_tutti_comb_5 == true){
            
                if(starting == true){
                    dialoghiManager.StartDialoghi("dg_boss_final");
                    fire_battle.SetActive(true);
                    final_combact.SetActive(true);
                    starting = false;
                }
            //}
        }
    }

    private void Update(){
    
        if(boss.GetComponent<BossHealth>().currentHealth <= 0){
           
            if(end == false){
                dialoghiManager.StartDialoghi("dg_sue_final");
                end = true;
            }
            if(dialoghiManager.FineDialogo("dg_sue_final")){
                tirgger_final_scene.SetActive(true);
                finito_livello_cairo = true;
                Destroy(comb_1);
                Destroy(comb_2);
                Destroy(comb_3);
                Destroy(comb_4);
                Destroy(comb_5);
                Destroy(boss);
            }

            if(player_storage.livello_finito == true){
                boss.SetActive(false);
                fire_battle.SetActive(false);
                fire_ending.SetActive(true);
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
    


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinalCombact : Combact {

    public DialoghiUIManager dialoghiManager;
    public GameObject player;
    private Animator anim_player;
    public GameObject boss;
    public GameObject fire_battle;
    public GameObject fire_ending;

    private void Start() {
        anim_player = player.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            player.GetComponent<PlayerMovement>().enabled = false;
            anim_player.SetBool("moving",false);
            fire_battle.SetActive(true);
            dialoghiManager.StartDialoghi("dialogo_boss_finale");
        }
    }

    private void Update() {
        if(dialoghiManager.FineDialogo("dialogo_boss_finale"))
        { 
            //dialogo iniziale finito puo iniziare ultimo combattimento 
            player.GetComponent<PlayerMovement>().enabled = true;
            anim_player.SetBool("moving",true);
            gameObject.SetActive(false);

        }
        else if(boss.GetComponent<BossHealth>().currentHealth <= 0)
        {
            fire_battle.SetActive(false);
            fire_ending.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            anim_player.SetBool("moving",false);
            dialoghiManager.StartDialoghi("dialogo_vittoria");

            if(dialoghiManager.FineDialogo("dialogo_vittoria"))
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                anim_player.SetBool("moving",true);
            }
            
        }
    }
}
    


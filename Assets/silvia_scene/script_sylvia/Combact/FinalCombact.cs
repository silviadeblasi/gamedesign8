using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinalCombact : MonoBehaviour {

    public DialoghiUIManager dialoghiManager;
    public GameObject player;
    private Animator anim_player;
    public BossController bossController;
    public GameObject boss;
    public GameManager gameManager;

    private void Start() {
        anim_player = player.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            player.GetComponent<PlayerMovement>().enabled = false;
            anim_player.SetBool("moving",false);
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
            bossController.enabled = true;
        }
        else if(boss.GetComponent<BossHealth>().currentHealth <= 0)
        {
            dialoghiManager.StartDialoghi("dialogo_vittoria");
            gameManager.current_scene.ToString("cutsceneFinale");
        }
    }
}
    


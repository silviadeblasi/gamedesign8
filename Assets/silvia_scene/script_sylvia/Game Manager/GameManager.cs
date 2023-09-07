using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Scene_Loader.Scene current_scene; //uso direttamente Scene_Loader perche ho gia l'elenco delle scene
    public GameObject player;
    private bool firstTime_StanzaSue = true;
    //private bool firstTime_EsternoLev1 = true;
    public SoundManager soundManager;
    public DialoghiUIManager dialoghiManager;
    public GameObject Camera;
    private bool fine_scenapostprologo = true;
    private bool commandnotshow = false;
    private bool amuleto = false;
    private bool flag_tomba = false;
    private bool just_once = true;
    public interactable_object canvas_trama;
    
    
    public CombactManager combactManager;
    private bool notalreadyhere = false;

    //devo dichiarare i 5 comb + finale e rendere inattivi appena rientro nella scena 
    public GameObject comb_1;
    public GameObject comb_2;
    public GameObject comb_3;
    public GameObject comb_4;
    public GameObject comb_5;
    public GameObject final_combact;
    public vector_value player_storage; //setto il bool dello scriptable object a true solo quando esco dalla casa del cairo
    //private PlayerInventory playerInventory;
    //private InventoryItem machete;

    private void Update() {

        //primissima scena stanza di sue di sue 
        
        if( current_scene.ToString() == "Stanza_sue"){
            if(firstTime_StanzaSue){
                soundManager.PlayBackgroundMusic("Casa2", 0.7f);
                player.GetComponent<PlayerMovement>().enabled = false;
                dialoghiManager.StartDialoghi("dg_st_2");
                Debug.Log("Stanza_sue");
                firstTime_StanzaSue = false;
                //dialoghiManager.StartUI("wasd"); 
            }
            
            if(dialoghiManager.FineDialogo("dg_st_2") == true){
                
                player.GetComponent<PlayerMovement>().enabled = true;
               
                if(commandnotshow == false){
                    dialoghiManager.StartUI("wasd");
                    player.GetComponent<PlayerMovement>().enabled = false;
                    commandnotshow = true;
                }

                if(dialoghiManager.FineUI("wasd") == true && fine_scenapostprologo == true){
                    fine_scenapostprologo = false;
                    StartCoroutine(FirstScene(Camera.GetComponent<Camera>()));
                }
            }

            if(dialoghiManager.FineDialogo("dg_st_1") == true){
                player.GetComponent<PlayerMovement>().enabled = true;
            }
        }

        if(current_scene.ToString() == "Casa_sue"){

            soundManager.PlayBackgroundMusic("Casa2", 0.7f);

            if (canvas_trama.pendant_trovato == true && amuleto == false){
                dialoghiManager.StartDialoghi("dg_cs_1");
                Debug.Log("dg_cs_1");
                amuleto = true;
            }
            dialoghiManager.FineDialogo("dg_cs_1");
        }

        if(current_scene.ToString() == "Esterno_lev1"){
            
            soundManager.PlayBackgroundMusic("TemaPrincipale2", 0.7f);

            if (canvas_trama.tomba_madre == true && flag_tomba == false){
                dialoghiManager.StartDialoghi("dg_sue_tomba");
                flag_tomba = true;
            }
            if(player_storage.livello_finito == true){
                just_once = false;
                //attivo flag casa del cairo e mi assicuro che tutti i combattimenti vengano distrutti (quindi gia fatti)
                //incluso boss finale
                combactManager.combactList[0].progress = GeneralCombact.CombactProgress.DONE;
                combactManager.combactList[1].progress = GeneralCombact.CombactProgress.DONE;
                combactManager.combactList[2].progress = GeneralCombact.CombactProgress.DONE;
                combactManager.combactList[3].progress = GeneralCombact.CombactProgress.DONE;
                combactManager.combactList[4].progress = GeneralCombact.CombactProgress.DONE;
                combactManager.combactList[5].progress = GeneralCombact.CombactProgress.DONE;
                // ok combact manager ma devo distruggere o rendere non visibili i combattimenti 
                //devo mettere nello scriptable object che il flag nel cabmio scena rimane true!!!!!!!
                Destroy(comb_1);
                Destroy(comb_2);
                Destroy(comb_3);
                Destroy(comb_4);
                Destroy(comb_5);
                // non facendo parte del combact manager devo eliminare il boss rendere agibile il muretto 
                
            }
            
        }
        
    }
    
    IEnumerator FirstScene(Camera main){

        yield return new WaitForSeconds(4f);
        StartCoroutine(FirstSceneCoroutine());    
        Camera.GetComponent<camera_movement>().enabled = false;
        Camera.GetComponent<CameraShake>().enabled = true;
        soundManager.PlaySoundEffect("Urla", 0.3f);
        soundManager.PlaySoundEffect("Rottura_vetro", 0.4f);
        
    }

    IEnumerator FirstSceneCoroutine() {
        yield return new WaitForSeconds(4f);
        player.GetComponent<PlayerMovement>().enabled = false;
        dialoghiManager.StartDialoghi("dg_st_1");
    }

    
}

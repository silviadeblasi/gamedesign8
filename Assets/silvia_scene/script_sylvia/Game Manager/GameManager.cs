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
    public GameObject Combattimento;

    private void Update() {

        //primissima scena stanza di sue di sue 
        
        if( current_scene.ToString() == "Stanza_sue"){
            if(firstTime_StanzaSue){
                soundManager.PlayBackgroundMusic("Casa2", 0.7f);
                player.GetComponent<PlayerMovement>().enabled = false;
                dialoghiManager.StartDialoghi("scena_postprologo");
                Debug.Log("Stanza_sue");
                firstTime_StanzaSue = false;
                //dialoghiManager.StartUI("wasd"); 
            }
            
            if(dialoghiManager.FineDialogo("scena_postprologo") == true){
                
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

            if(dialoghiManager.FineDialogo("scena 1") == true){
                player.GetComponent<PlayerMovement>().enabled = true;
            }
        }

        if(current_scene.ToString() == "Casa_sue"){

            soundManager.PlayBackgroundMusic("Casa2", 0.7f);

            if (canvas_trama.pendant_trovato == true && amuleto == false){
                dialoghiManager.StartDialoghi("pendant_dialogue");
                amuleto = true;
            }
            dialoghiManager.FineDialogo("pendant_dialogue");
        }

        if(current_scene.ToString() == "Esterno_lev1"){

            soundManager.PlayBackgroundMusic("TemaPrincipale2", 0.7f);

            if(canvas_trama.tomba_madre == true && flag_tomba == false){
                dialoghiManager.StartDialoghi("tomba_madre");
                flag_tomba = true;
            }
            bool enemies = ((Combattimento.transform.Find("Combattimento (1)")?.gameObject).transform.Find("enemies (1.1)")?.gameObject).activeInHierarchy;
            if(((Combattimento.transform.Find("Combattimento (1)")?.gameObject).transform.Find("enemies (1.1)")?.gameObject).activeInHierarchy == false && ((Combattimento.transform.Find("Combattimento (1)")?.gameObject).transform.Find("enemies (1.2)")?.gameObject).activeInHierarchy == false && ((Combattimento.transform.Find("Combattimento (1)")?.gameObject).transform.Find("enemies (1.3)")?.gameObject).activeInHierarchy == false && just_once == true){
                dialoghiManager.StartDialoghi("fine_combattimento_1");
                just_once = false;
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
        dialoghiManager.StartDialoghi("scena 1");
    }

    
}

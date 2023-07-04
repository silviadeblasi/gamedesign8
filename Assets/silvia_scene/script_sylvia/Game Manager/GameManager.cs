using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = new GameManager();
    public Scene_Loader.Scene current_scene; //uso direttamente Scene_Loader perche ho gia l'elenco delle scene
    public GameObject player;
    private bool firstTime_StanzaSue = true;
    private bool firstTime_CasaSue = true;
    private bool firstTime_EsternoLev1 = true;
    public SoundManager soundManager;
    public DialoghiUIManager dialoghiManager;
    public GameObject Camera;
    private bool fine_scenapostprologo = true;
    private bool commandnotshow = false;
    private bool amuleto = false;
    public interactable_object canvas_trama;
    

    /*private GameManager(){
        //current_scene = Scene_Loader.Scene.start_menu;
    }

    public static GameManager Instance{
        get{
            return instance;
        }
    }
    /*private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }*/

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
            if(firstTime_CasaSue)
                soundManager.PlayBackgroundMusic("Casa2", 0.7f);
                if (canvas_trama.pendant_trovato == true){
                   amuleto = true;
                }
                if(amuleto == true){
                    dialoghiManager.StartDialoghi("pendant_dialogue");
                    amuleto = false;
                }
        }

        if(current_scene.ToString() == "Esterno_lev1"){
            Debug.Log("Esterno_lev1");
            //soundManager.PlayBackgroundMusic("Esterno");
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

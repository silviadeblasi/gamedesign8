using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Scene_Loader.Scene current_scene; //uso direttamente Scene_Loader perche ho gia l'elenco delle scene
    public GameObject player;
    private bool firstTime = true;
    public SoundManager soundManager;
    public DialoghiUIManager dialoghiManager;
    public GameObject Camera;
    private bool finedialogo = false;
    private bool fine_scenapostoprologo = false;
    
    private void Update() {

        //primissima scena stanza di sue di sue 
        
        if( current_scene.ToString() == "Stanza_sue"){

            if(firstTime){
                player.GetComponent<PlayerMovement>().enabled = false;
                dialoghiManager.StartDialoghi("scena_postoprologo");
                Debug.Log("Stanza_sue");
                firstTime = false;
            }

            
            finedialogo = dialoghiManager.FineDialogo("scena_postoprologo");
            finedialogo = dialoghiManager.FineDialogo("scena 1");
            
            if(finedialogo == true){
                player.GetComponent<PlayerMovement>().enabled = true;
                fine_scenapostoprologo = true;
            }

            if(fine_scenapostoprologo == true){
                soundManager.PlayBackgroundMusic("Casa");
                dialoghiManager.StartUI("wasd");
                //StartCoroutine(FirstScene(Camera.GetComponent<Camera>()));
            }
        }

        if(current_scene.ToString() == "Casa_sue"){
            Debug.Log("Casa_sue");
            //soundManager.PlayBackgroundMusic("Casa");
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
        soundManager.PlaySoundEffect("Urla");
        soundManager.PlaySoundEffect("Rottura_vetro");
        
    }

    IEnumerator FirstSceneCoroutine() {
        yield return new WaitForSeconds(4f);
        dialoghiManager.StartDialoghi("scena 1");
    }
}

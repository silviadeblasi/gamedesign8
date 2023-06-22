using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Scene_Loader.Scene current_scene; //uso direttamente Scene_Loader perche ho gia l'elenco delle scene
    public GameObject player;
    private bool firstTime = true;
    public SoundManager soundManager;
    public DialoghiManager dialoghiManager;
    public GameObject Camera;
    
    private void Update() {

        if( current_scene.ToString() == "Stanza_sue"){
            if(firstTime){
            //player.GetComponent<PlayerMovement>().enabled = false;
            //FirstScene(Camera.GetComponent<Camera>());
            Debug.Log("Stanza_sue");
            firstTime = false;
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
    
    private void FirstScene(Camera main){
        //StartCoroutine(FirstSceneCoroutine(main));
        Camera.GetComponent<CameraShake>().enabled = true;
        Camera.GetComponent<camera_movement>().enabled = false;
        soundManager.PlaySoundEffect("Urla");
        soundManager.PlaySoundEffect("Rottura_vetro");
    }

    /*IEnumerator FirstSceneCoroutine(Camera main){

        yield return new WaitForSeconds(1f);
        main.transform.position = new Vector3(0.2f,0.2f, 0);
        yield return new WaitForSeconds(1f);
        main.transform.position = new Vector3(0,0, 0);
        yield return new WaitForSeconds(1f);
        main.transform.position = new Vector3(-0.2f,-0.2f, 0);
        yield return new WaitForSeconds(1f);
        main.transform.position = new Vector3(0,0, 0);
        
    }*/
}

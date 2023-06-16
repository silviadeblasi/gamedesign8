using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager;
    public GameObject player;

    private void Awake() {
        if(gamemanager == null){
            gamemanager = this;
        }
        else if(gamemanager != this){
            Destroy(gameObject);
        }
    }

    public void StartingGame(Scene scene){
        if(scene.sceneName == "Stanza_sue"){
            if(scene.isFirstTime){
                player.SetActive(true);
            }
        }
    }
}

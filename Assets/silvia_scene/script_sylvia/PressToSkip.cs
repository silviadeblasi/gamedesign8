using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PressToSkip : MonoBehaviour {
    public VideoPlayer prologo;
    private void Start() {
        prologo.loopPointReached += AllVideo;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Scene_Loader.Load(Scene_Loader.Scene.Stanza_sue);
        }
    }

    void AllVideo(VideoPlayer vp){
        Debug.Log("Mortacci");
       Scene_Loader.Load(Scene_Loader.Scene.Stanza_sue); 
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload_player : MonoBehaviour
{
    //public vector_value last_position; //forse basta solo sapere la poszione dei checkpoint
    public FloatValue currentHealth;
    public GameObject gameOverCanvas;
    private GameObject clonedialogue;
    //public GameObject last_scheckpoint;
    public vector_value_scene checkpoint_position;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth.RuntimeValue == 0){
            clonedialogue =(GameObject)GameObject.Instantiate(gameOverCanvas, transform.position, Quaternion.identity);
            Destroy(clonedialogue,5f);
        //qui parte animazione morte

            Respawn(); //faccio una coroutine per farlo respawnare dopo qaulche secondi il tempo di mostrare animazione morte
        }
    }

    public void Respawn(){
        SceneManager.LoadScene(checkpoint_position.Scenename);
        player.transform.position = checkpoint_position.initialValue;
        currentHealth.RuntimeValue = 10;

    }
}

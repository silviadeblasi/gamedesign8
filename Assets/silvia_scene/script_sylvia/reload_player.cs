using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload_player : MonoBehaviour
{
    //public vector_value last_position; //forse basta solo sapere la poszione dei checkpoint
    public PlayerHealth currentHealth_player;
    public HeartManager playerHealth;
    public GameObject gameOverCanvas;
    private GameObject clonedialogue;
    //public GameObject last_scheckpoint;
    public vector_value_scene checkpoint_position;
    public GameObject player;
    public bool isDead = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.playerCurrentHealth.RuntimeValue == 0 && isDead == false){
            Debug.Log("morto");
            //clonedialogue = (GameObject)GameObject.Instantiate(gameOverCanvas, transform.position, Quaternion.identity);
            //Destroy(clonedialogue,5f);
            gameOverCanvas.SetActive(true);
            isDead = true;
        //qui parte animazione morte

            StartCoroutine(WaitAndRespawn()); //faccio una coroutine per farlo respawnare dopo qaulche secondi il tempo di mostrare animazione morte
        }
    }

    /*public void Respawn(){
        SceneManager.LoadScene(checkpoint_position.Scenename);
        player.transform.position = checkpoint_position.initialValue;
        currentHealth.RuntimeValue = 10;

    }*/

    private IEnumerator WaitAndRespawn(){
        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene(checkpoint_position.Scenename);
        player.transform.position = checkpoint_position.initialValue;
        playerHealth.playerCurrentHealth.RuntimeValue = 6;
        currentHealth_player.currentHealth = 6;
        playerHealth.UpdateHearts();
        isDead = false;
    }
}

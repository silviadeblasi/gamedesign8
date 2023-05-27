using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCInteractable : MonoBehaviour {
    private GameObject dialogueBoxClone;

    [SerializeField] GameObject dialogueBoxPrefab1;
    [SerializeField] GameObject dialogueBoxPrefab2;
    [SerializeField] GameObject dialogueBoxPrefab3;
   [SerializeField] GameObject dialogueBoxPrefab4;
    private GameObject _clone_dialogue_ended;

    public void Interact(int num, int max)
    {
        Debug.Log("interazione con NPC");


        if (num == 0)
            dialogueBoxClone = (GameObject)GameObject.Instantiate(dialogueBoxPrefab1, transform.position, Quaternion.identity);
        Debug.Log(transform.position);
        Debug.Log("istanziato assegnazione compito");
        //animazione

        if (num < max && num != 0)
            dialogueBoxClone = (GameObject)GameObject.Instantiate(dialogueBoxPrefab2, transform.position, Quaternion.identity);
        Debug.Log("compito da concludere");
        //animazione

        if (num == max)
            dialogueBoxClone = (GameObject)GameObject.Instantiate(dialogueBoxPrefab3, transform.position, Quaternion.identity);
        Debug.Log("compito concluso");
        //animazione

    }


    public void StopInteract()
    {
        Debug.Log("stop interazione con NPC");
        //animazione

        //chiudo dialogue Box
        Destroy(dialogueBoxClone);
        Debug.Log("distrutto dialogBox");

        //confermo chiusura dialogo 
        //mostro a schermo per 2 secondi la scritta dove si dice di premere E per chiudere il dialogo
        _clone_dialogue_ended = (GameObject)GameObject.Instantiate(dialogueBoxPrefab4, transform.position, Quaternion.identity);
        Destroy(_clone_dialogue_ended, 2f);


    }


}
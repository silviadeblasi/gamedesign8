using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DialoghiUIManager : MonoBehaviour
{
    public GameObject[] dialoghi; //solo dialoghi (capire ancora se devo aggiungere un altra categoria per NPC e player)
    private dialogue_script dialogo_fine; //dialogo fine scena
    public GameObject[] UI; //ad esempio tutorial o altro che deve essere comunicato interente al gioco 
    private GameObject CloneDialogueBox; //clona il dialogo per poterlo usare in altre scene(non devo inserire il dialogo nella scena ma mi clona il riferimento nei prefab)
    public bool finedialogo = false; // variabile che uso nel game manager per capire se il dialogo è finito
    private bool dialogo_iniziato = false;
    private void Awake() {
       
    }

    private void Update() {
        //Debug.Log(dialogo_fine.fine_dialogo);
        if(dialogo_fine!=null && dialogo_fine.fine_dialogo == true){
            finedialogo = true;
            Debug.Log("fine dialogo");
        }
    }

    public void StartDialoghi(string dialogo_name){
        GameObject dialogo = FindDialoghi(dialoghi, dialogo_name);
        if(dialogo != null){
            dialogo_iniziato = true;
            CloneDialogueBox = (GameObject)GameObject.Instantiate(dialogo, transform.position, Quaternion.identity);
            dialogo_fine = (dialogo.transform.Find("dialogueBox")?.gameObject).GetComponent<dialogue_script>();
            dialogo_fine = (CloneDialogueBox.transform.Find("dialogueBox")?.gameObject).GetComponent<dialogue_script>(); //trovo lo script che gestisce il dialogo
        }
        else{
            Debug.LogWarning("Dialogo non trovato: " + dialogo_name);
        }
        

    }

    // mi fa comparire il dialogo in base al nome 
    private GameObject FindDialoghi(GameObject[] dialpoghi, string dialogo_name){
        foreach (GameObject dialogo in dialoghi)
        {
            if(dialogo.name == dialogo_name){
                return dialogo;
            }
        }
        return null;
    }

    //questa funzione la chiamero in update per controllare ogni frame il bool fine dialogo che sta nello script del dialogo
    public bool FineDialogo(string dialogo_name){
        GameObject dialogo = FindDialoghi(dialoghi, dialogo_name); //trovo il dialogo
        //verifico che il dialogo è inziato 
        if(dialogo_iniziato == true){
            if(dialogo_fine.fine_dialogo == true){
                Debug.Log(dialogo_fine.fine_dialogo);
                return finedialogo = true;
            }
        }
        return finedialogo = false;
    }
}
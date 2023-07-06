using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DialoghiUIManager : MonoBehaviour
{
    public GameObject[] dialoghi; //solo dialoghi (capire ancora se devo aggiungere un altra categoria per NPC e player)
    private dialogue_script dialogo_fine; //dialogo fine scena
    public GameObject[] UI; //ad esempio tutorial o altro che deve essere comunicato interente al gioco 
    private UI_script ui_fine; //ui fine scena
    private GameObject CloneDialogueBox; //clona il dialogo per poterlo usare in altre scene(non devo inserire il dialogo nella scena ma mi clona il riferimento nei prefab)
    private GameObject CloneUI; //clona il dialogo per poterlo usare in altre scene(non devo inserire il dialogo nella scena ma mi clona il riferimento nei prefab)
    public bool finedialogo = false; // variabile che uso nel game manager per capire se il dialogo è finito
    public bool fineUI = false; // variabile che uso nel game manager per capire se il dialogo è finito
    private bool dialogo_iniziato = false;
    private bool UI_iniziato = false;
    private void Awake() {
       
    }

    private void Update() {
        //Debug.Log(dialogo_fine.fine_dialogo);
        if(dialogo_fine!=null && dialogo_fine.fine_dialogo == true){
            finedialogo = true;
            Debug.Log("fine dialogo");
        }

        if(ui_fine!=null && ui_fine.fine_ui == true){
            fineUI = true;
            Debug.Log("fine ui");
        }
    }

    public void StartDialoghi(string dialogo_name){
        GameObject dialogo = FindDialoghi(dialoghi, dialogo_name);
        if(dialogo != null){
            dialogo_iniziato = true;
            CloneDialogueBox = (GameObject)GameObject.Instantiate(dialogo, transform.position, Quaternion.identity);
            dialogo_fine = (CloneDialogueBox.transform.Find("dialogueBox")?.gameObject).GetComponent<dialogue_script>(); //trovo lo script che gestisce il dialogo
        }
        else{
            Debug.LogWarning("Dialogo non trovato: " + dialogo_name);
        }
        

    }

    // mi fa comparire il dialogo in base al nome 
    private GameObject FindDialoghi(GameObject[] dialoghi, string dialogo_name){
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
                Destry(CloneDialogueBox);
            }
        }
        return finedialogo = false;
    }

    public void StartUI(string UI_name){
        GameObject ui = FindUI(UI, UI_name);
        if(ui != null){
            UI_iniziato = true;
            GameObject CloneUI = (GameObject)GameObject.Instantiate(ui, transform.position, Quaternion.identity);
            ui_fine = (CloneUI.transform.Find("Panel")?.gameObject).GetComponent<UI_script>();

        }
        else{
            Debug.LogWarning("UI non trovato: " + ui);
        }
    }

    private GameObject FindUI(GameObject[] UI, string UI_name){
        foreach (GameObject ui in UI)
        {
            if(ui.name == UI_name){
                return ui;
            }
        }
        return null;
    }

    public bool FineUI(string UI_name){
        GameObject ui = FindUI(UI, UI_name);
        if(UI_iniziato)
            if(ui_fine.fine_ui == true){
                return fineUI = true;
            }
        return fineUI = false;
    }
}
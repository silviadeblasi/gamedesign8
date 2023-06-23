using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DialoghiUIManager : MonoBehaviour
{
    //public List<GameObject> dialoghi = new List<GameObject>(); //solo dialoghi (capire ancora se devo aggiungere un altra categoria per NPC e player)
    public GameObject[] dialoghi; //solo dialoghi (capire ancora se devo aggiungere un altra categoria per NPC e player)
    public GameObject[] UI; //ad esempio tutorial o altro che deve essere comunicato interente al gioco 
    private GameObject CloneDialogueBox; //clona il dialogo per poterlo usare in altre scene(non devo inserire il dialogo nella scena ma mi clona il riferimento nei prefab)

    private void Awake() {
       
    }

    public void StartDialoghi(string dialogo_name){
        GameObject dialogo = FindDialoghi(dialoghi, dialogo_name);

        if(dialogo != null){
            CloneDialogueBox = (GameObject)GameObject.Instantiate(dialogo, transform.position, Quaternion.identity);
        }
        else{
            Debug.LogWarning("Dialogo non trovato: " + dialogo_name);
        }
    }

    /*public void StartDialoghi(){
        //CloneDialogueBox = (GameObject)GameObject.Instantiate(dialoghi, transform.position, Quaternion.identity);
    }*/
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





}
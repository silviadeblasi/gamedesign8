using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_interactable : MonoBehaviour
{
    private Animator anim;
    public DialoghiUIManager dialoghiUIManager; //cerco i dialoghi e li faccio comparire

    private void Start() {

        anim = GetComponent<Animator>();
    }

    public void Interact(bool done){
        Debug.Log("interact");

    }
   
}

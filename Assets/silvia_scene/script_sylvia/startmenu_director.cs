using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class startmenu_director : MonoBehaviour
{
//variabili bottoni, possibile premerli solo alla fine dell'animazione
public Button start_button;
public Button load_button;
public Button option_button;
public Button exit_button;
public Button credits_button;
public Button tutorial_button;

public PlayableDirector timeline_paper; //timeline

    void Start(){

        timeline_paper = GetComponent<PlayableDirector>(); //timeline

        start_button = start_button.GetComponent<Button>();
        load_button = load_button.GetComponent<Button>();
        option_button = option_button.GetComponent<Button>();
        exit_button = exit_button.GetComponent<Button>();
        credits_button = credits_button.GetComponent<Button>();
        tutorial_button = tutorial_button.GetComponent<Button>();

        start_button.enabled = false;
        load_button.enabled = false;
        option_button.enabled = false;
        exit_button.enabled = false;
        credits_button.enabled = false;
        tutorial_button.enabled = false;

    //check sulla timeline per capire se si è conclusa animazione
    //inserire i bottoni come variabili per renderli attivi solo alla fine dell'animazione
    //controllo eventuale audio 
    //controllo eventuale animazione
 }

    void Update() {
        if (timeline_paper.state == PlayState.Paused) {
            start_button.interactable = true;
            load_button.interactable = true;
            option_button.interactable = true;
            exit_button.interactable = true;
            credits_button.interactable = true;
            tutorial_button.interactable = true;
        }
    }
}
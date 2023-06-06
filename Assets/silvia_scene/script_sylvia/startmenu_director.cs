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
        

        start_button.gameObject.SetActive(false);
        load_button.gameObject.SetActive(false);
        option_button.gameObject.SetActive(false);
        exit_button.gameObject.SetActive(false);
        credits_button.gameObject.SetActive(false);
        tutorial_button.gameObject.SetActive(false);
    //check sulla timeline per capire se si è conclusa animazione
    //inserire i bottoni come variabili per renderli attivi solo alla fine dell'animazione
    //controllo eventuale audio 
    //controllo eventuale animazione
 }

    void Update() {

        Debug.Log(timeline_paper.state);

        if (timeline_paper.state == PlayState.Paused) {
            start_button.gameObject.SetActive(true);
            load_button.gameObject.SetActive(true);
            option_button.gameObject.SetActive(true);
            exit_button.gameObject.SetActive(true);
            credits_button.gameObject.SetActive(true);
            tutorial_button.gameObject.SetActive(true);
        }
        
    }
}
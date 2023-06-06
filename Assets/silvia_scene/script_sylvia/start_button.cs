using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class start_button :MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    bool isPressed = false;
    public AudioSource sound_pressed;
    void Start()
    {
        sound_pressed.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            
            sound_pressed.enabled = true;
            //mettere animazione
            //mettere cambio scena
            StartCoroutine(TimeDelay());
        }
    }
    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1);
        Scene_Loader.Load(Scene_Loader.Scene.Casa_sue);
    }

    /*public IEnumerator PlaySound()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        sound_pressed.gameObject.SetActive(true);
    }*/

     public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      isPressed = false;
    }
}

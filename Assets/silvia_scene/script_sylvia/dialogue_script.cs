using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue_script : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool fine_dialogo = false;
    public int _index;

    //audio
    [SerializeField] private AudioClip _soundeffect;
    private AudioSource audioSource;

    [SerializeField] private bool stopAudioSource;
    private int maxvisibleCharacter;

    [Range(1,5)]
    [SerializeField] private int frequencyLevel = 2;

    
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        
    }

    // Update is called once per frame
    void Update()
    {
        
     if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (textComponent.text == lines[_index]){
                NextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = lines[_index];  
            }
        }
    }

    void StartDialogue(){
        _index = 0;
        audioSource = this.gameObject.AddComponent<AudioSource>();
        StartCoroutine(TypeLine());
    }

    //coroutine per la scrittura del testo
    IEnumerator TypeLine()
    {
        foreach (char letter in lines[_index].ToCharArray())
        { //prende stringa e la divide into char array
            textComponent.text += letter;
            PlayDialogueSound(maxvisibleCharacter);
            maxvisibleCharacter++;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if (_index < lines.Length - 1){
            _index++;
            textComponent.text = string.Empty;
            maxvisibleCharacter = 0;
            StartCoroutine(TypeLine());
        }
        else{
            textComponent.text = string.Empty;
            fine_dialogo = true;
        }
    }

    void PlayDialogueSound(int maxvisibleCharacter){
        if (maxvisibleCharacter % frequencyLevel == 0){
            if(stopAudioSource)
                audioSource.Stop();
            audioSource.PlayOneShot(_soundeffect);
        }
    }
}

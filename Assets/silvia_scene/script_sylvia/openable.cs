using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openable : MonoBehaviour
{
    private Animator anim;
    public GameObject comunicazione_comandi;
    private GameObject comunicazione_comandi_clone;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        comunicazione_comandi_clone = (GameObject)GameObject.Instantiate(comunicazione_comandi, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        Debug.Log("sono dentro open");
        anim.SetBool("open", true);
        StartCoroutine(openCo());
        Destroy(comunicazione_comandi_clone, 0.5f);
        
        
    }

    IEnumerator openCo()
    {
        //in questo caso il baule non deve scomparire ma deve rimanere aperto per sempre
        // piuttosto deve partire animazione della mappa che sale 
        //e il dialogue box che ti informa che hai trovato la mappa e puoi aprirla premendo M
        yield return new WaitForSeconds(.3f);
        //this.gameObject.SetActive(false);
    }
}

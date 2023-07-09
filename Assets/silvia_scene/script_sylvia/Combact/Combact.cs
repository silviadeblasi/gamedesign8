using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Combact : MonoBehaviour
{
    public bool _inTrigger = false;
    public GameObject trigger_startcombact;
    public List<int> availableCombactIDs = new List<int> ();
    public int receivableCombactID;
    public GameObject combattimento;
    //public GameObject _combactAvailable;
    //public GameObject _combactCompleted;
    public Combact combact;
    //public GameObject coffeeQuestSign;

    public void Start()
    {

        SetCombact();
        combact = GetComponent<Combact>();
    }
    //questo magari protrebbe servirmi a far comparire i nemici morti 
    public void SetCombact()
    {
        if (CombactManager.combactManager.CheckCompleteCombact(this))
        {
            combattimento.SetActive(false);
            //_combactCompleted.SetActive(true);
            //coffeeQuestSign.SetActive(false);
        }
        else if (CombactManager.combactManager.CheckAvailableCombact(this))
        {
            if (CombactManager.combactManager.combactList.Exists(GeneralCombact => GeneralCombact.progress == GeneralCombact.CombactProgress.ACCEPTED)){

            }
                //_combactAvailable.SetActive(false);
            else
            {
                if (CombactManager.combactManager.FirstCombactDone)
                {
                    //_combactAvailable.SetActive(true);
                } else
                {
                    //_combactAvailable.SetActive(false);
                    if(!CombactManager.combactManager.CheckCompleteCombact(this)){
                        combattimento.SetActive(true);

                    }
                        //coffeeQuestSign.SetActive(true);
                }
            }
                //_questAvailable.SetActive(true);
        } else
        {
            combattimento.SetActive(true);
           // _combactAvailable.SetActive(false);
            //_combactCompleted.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            _inTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            _inTrigger = false;
    }

    public void LookAtPlayer(Transform Player)
    {
        transform.LookAt(Player.transform);
    }

}

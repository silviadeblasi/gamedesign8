using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CombactManager : MonoBehaviour
{

    public static CombactManager combactManager;
    public List<GeneralCombact> combactList = new List<GeneralCombact> ();
    public GeneralCombact currentCombact = null;
    public bool FirstCombactDone = false;

    private void Awake()
    {
        if (combactManager == null)
            combactManager = this;
        else if (combactManager != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void CombactRequest(Combact combact)
    {
        //available quests
        if(combact.availableCombactIDs.Count > 0)
        {
            for(int i= 0; i < combactList.Count; i++)
            {
                for(int j=0; j < combact.availableCombactIDs.Count; j++)
                {
                    if (combactList[i].id == combact.availableCombactIDs[j] && combactList[i].progress == GeneralCombact.CombactProgress.AVAILABLE)
                    {
                        Debug.Log("Quest ID: " + combact.availableCombactIDs[j] + " " + combactList[i].progress);
                        AcceptCombact(combact.availableCombactIDs[j]);
                        //quest ui manager
                    }
                }
            } 
        }
       
        //active quest
        /*if(currentCombact.id == combact.receivableCombactID && currentCombact.progress == GeneralCombact.CombactProgress.ACCEPTED || currentCombact.progress == GeneralCombact.CombactProgress.DONE)
        {
           
            Debug.Log("combact ID: " + combact.receivableCombactID + " is " + currentCombact.progress);
            CompleteCombact(combact.receivableCombactID);
        }*/

        if(currentCombact.id == combact.receivableCombactID && currentCombact.progress == GeneralCombact.CombactProgress.DONE)
        {
            currentCombact.id = -1;
        }

    }


    //ACCEPT QUEST
    public void AcceptCombact(int combactID)
    {
        Debug.Log("Accept Quest");
        for(int i = 0; i < combactList.Count; i++)
        {
            Debug.Log(currentCombact.id);
            if (combactList[i].id == combactID && combactList[i].progress == GeneralCombact.CombactProgress.AVAILABLE && currentCombact.id == -1)
            {
                Debug.Log("tanto lo so che qui non arrivi mai bastardo");
                combactList[i].progress = GeneralCombact.CombactProgress.ACCEPTED;
                currentCombact = combactList[i];
            } else if (currentCombact.id != -1)
            {
                Debug.Log("Previous task not completed");
            }
        }
    }

    //COMPLETE QUEST

    public void CompleteCombact(int combactID)
    {
        if(currentCombact.id == combactID && currentCombact.progress == GeneralCombact.CombactProgress.DONE)
        {
            currentCombact.id = -1;
        }
    }

    //BOOLS
    public bool RequestAvailableQuest(int combactID)
    {
        for(int i=0; i<combactList.Count; i++)
        {
            if (combactList[i].id == combactID && combactList[i].progress == GeneralCombact.CombactProgress.AVAILABLE)
                return true;
        }
        return false;
    }

    public bool RequestAcceptedQuest(int combactID)
    {
        if (currentCombact.id == combactID)
            return true;
        return false;
    }

    public bool RequestCompleteQuest(int combactID)
    {
        for (int i = 0; i < combactList.Count; i++)
        {
            if (combactList[i].id == combactID && combactList[i].progress == GeneralCombact.CombactProgress.COMPLETE)
                return true;
        }
        return false;
    }

    public bool RequestFinishedQuest(int combactID)
    {
        for (int i = 0; i < combactList.Count; i++)
        {
            if (combactList[i].id == combactID && combactList[i].progress == GeneralCombact.CombactProgress.DONE)
                return true;
        }
        return false;
    }



    //BOOLS 2
    public bool CheckAvailableCombact(Combact combact)
    {
        for (int i = 0; i < combactList.Count; i++)
        {
            for(int j=0; j<combact.availableCombactIDs.Count; j++)
            {
                if (combactList[i].id == combact.availableCombactIDs[j] && combactList[i].progress == GeneralCombact.CombactProgress.AVAILABLE)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckAcceptedCombact(Combact combact)
    {
        for (int i = 0; i < combactList.Count; i++)
        {
            for (int j = 0; j < combact.availableCombactIDs.Count; j++)
            {
                if (combactList[i].id == combact.availableCombactIDs[j] && combactList[i].progress == GeneralCombact.CombactProgress.ACCEPTED)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCompleteCombact(Combact combact)
    {
        for (int i = 0; i < combactList.Count; i++)
        {
            if (combactList[i].id == combact.receivableCombactID && combactList[i].progress == GeneralCombact.CombactProgress.DONE)
            {
                return true;
            }
        }
        return false;
    }

    //check if everything is done
    public bool CheckEverythingDone()
    {
        Debug.Log("CheckEverythingDone");
        int contatoreDone = 0;
        for(int i=0; i<combactList.Count; i++)
        {
            if (combactList[i].progress == GeneralCombact.CombactProgress.DONE)
                contatoreDone++;
                Debug.Log("contatoreDone: " + contatoreDone);
        }
        if(contatoreDone == combactList.Count)
        {
            Debug.Log("Ti prego gesu");
            return true;
        }
        return false;
    }

}

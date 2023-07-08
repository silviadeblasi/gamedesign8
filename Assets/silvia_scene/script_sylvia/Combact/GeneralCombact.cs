using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeneralCombact
{
    public enum CombactProgress { AVAILABLE, ACCEPTED, COMPLETE, DONE};

    public string title;
    public int id;
    public CombactProgress progress;
    public string description;

    public string questObjective;   //name of the quest objective
    public int CombactObjectiveCount; //current number of enemies killed
    public int CombactObjectiveRequirement; //required amount of enemies to kill
}

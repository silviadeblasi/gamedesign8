using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    public FloatValue playerHealth;
    [SerializeField] private reload_player reload_Player; 
    public Signal healthSignal;


    public void Use(int amountToIncrease)
    {
        reload_player.Instance.currentHealth_player.currentHealth += amountToIncrease; 
        playerHealth.RuntimeValue += amountToIncrease;
        healthSignal.Raise();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHelath;
    public int maxHealth;

    void Start()
    {

    }

    void Update() 
    {
        
    }

    public void Damage(float damage)
    {
        currentHelath -= damage;
        if(currentHelath <= 0)
        {
            gameObject.SetActive(false); //non posso distruggerlo
            
        }
    }
}

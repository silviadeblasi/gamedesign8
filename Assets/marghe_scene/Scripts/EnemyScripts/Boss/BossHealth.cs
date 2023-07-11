using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float currentHealth;
    public int maxHealth;
    public BossController bossController;
    
    public void Damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            bossController.Die();
            gameObject.SetActive(false);
        }
        
    }
}

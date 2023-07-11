using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float currentHealth;
    public int maxHealth;
    [SerializeField] private Animator animator;
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            animator.SetBool("died", true);
            gameObject.SetActive(false);
        }
        
    }
}

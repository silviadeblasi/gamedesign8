using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int health = 20;
    [SerializeField] private Animator animator;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            animator.SetBool("died", true);
            gameObject.SetActive(false);
        }
        
    }
}

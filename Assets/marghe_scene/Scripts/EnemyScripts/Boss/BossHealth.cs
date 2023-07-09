using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int bossHealth = 20;
    public GameObject deathEffect;
    public bool isInvulnerable = false;
    
    public void TakeDamage(int damage)
    {
        if(isInvulnerable)
        {
            return;
        }

        bossHealth -= damage;

        if(bossHealth <= 10)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }

        if(bossHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float currentHealth;
    public int maxHealth;
    public BossController bossController;
    public BossShooting bossShooting;
    public Animator animator;
    
    public void Damage(float damage)
    {
        currentHealth -= damage;
        StartCoroutine(DamageCo());
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DamageCo()
    {
        animator.SetBool("stagger", true);
        yield return null;
        animator.SetBool("stagger", false);
    }
}

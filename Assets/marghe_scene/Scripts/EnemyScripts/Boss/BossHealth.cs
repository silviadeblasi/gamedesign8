using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float currentHelath;
    public int maxHealth;
    public Animator animator;

    public void Damage(float damage)
    {
        currentHelath -= damage;
        if(currentHelath <= 0)
        {
            gameObject.SetActive(false); //non posso distruggerlo
        }
    }

    private void Update() 
    {
        if(currentHelath <= 0)
        {
            animator.GetComponent<Animator>().SetBool("died", true);
        }
        else if(currentHelath < 10)
        {
            animator.GetComponent<Animator>().SetBool("isEnraged", true);
        }
    }
}

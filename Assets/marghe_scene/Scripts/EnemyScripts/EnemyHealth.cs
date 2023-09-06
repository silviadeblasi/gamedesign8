using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHelath;
    public int maxHealth;
    public EnemyController1 enemyController1;
    public Animator myAnim;

    public void Damage(float damage)
    {
        currentHelath -= damage;
        StartCoroutine(DamageCo());
        if(currentHelath <= 0)
        {
            enemyController1.Die();
            gameObject.SetActive(false); //non posso distruggerlo
        }
    }

    private IEnumerator DamageCo()
    {
        myAnim.SetBool("stagger", true);
        yield return null;
        myAnim.SetBool("stagger", false);
    }
}

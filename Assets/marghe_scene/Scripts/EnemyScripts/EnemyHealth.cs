using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHelath;
    public int maxHealth;
    public EnemyController enemyController;
    public void Damage(float damage)
    {
        currentHelath -= damage;
        if(currentHelath <= 0)
        {
            enemyController.Die();
            gameObject.SetActive(false); //non posso distruggerlo
        }
    }
}

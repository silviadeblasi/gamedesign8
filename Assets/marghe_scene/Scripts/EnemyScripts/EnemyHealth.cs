using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public FloatValue maxHealth;
    public float health;
    private Animator myAnim;

    private void Awake() 
    {
        health = (int)maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            //this.gameObject.SetActive(false);
            // Da implementare: animazione di morte
            Debug.Log("Enemy died.");
            myAnim.SetBool("dead", true);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if(myRigidbody != null) //Controlla se l'enemy è ancora vivo
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.velocity = Vector2.zero;
        }
        else
        {
            myAnim.SetBool("dead", true);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
    }
}

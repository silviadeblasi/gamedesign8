using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class GeneralEnemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public Animator myAnimator;

    private void Awake() 
    {
        health = (int)maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;

        myAnimator.SetTrigger("hurt");

        if(health <= 0)
        {
            //this.gameObject.SetActive(false);
            // Da implementare: animazione di morte
            Debug.Log("Enemy " + enemyName + " died.");
            myAnimator.SetBool("isDead", true);
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
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
        else
        {
            yield return null; //Se l'enemy è morto, non fa niente (non lo spinge)
            // Da implementare: animazione di morte
        }
    }
}

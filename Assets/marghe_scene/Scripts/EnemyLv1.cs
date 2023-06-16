using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLv1 : GeneralEnemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        //anim.SetFloat("moveX", 0);
        //anim.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    private void FixedUpdate() {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position,transform.position) > attackRadius)
        {
            if(currentState == EnemyState.idle || currentState != EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("walking", true);
            }

            if(currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                StartCoroutine(AttackCo());
            }

        } else{
            anim.SetBool("walking", false);
            ChangeState(EnemyState.idle);
        }
        
    }

    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
            
        }
    }

    private IEnumerator AttackCo() 
    {
        yield return new WaitForSeconds(.6f);
        anim.SetBool("attacking", true);
        currentState = EnemyState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(.1f);
        currentState = EnemyState.walk;
    }

}

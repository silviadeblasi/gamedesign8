using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState2
{
    idle,
    walk,
    attack,
    hurt,
    dead
}

public class EnemyMovement : MonoBehaviour
{
    public EnemyState2 currentState;
    private Rigidbody2D enemyRigidbody;
    public Animator enemyAnimator;
    private Transform enemyTarget;
    public Transform enemyHomePosition;
    [SerializeField] private float speedEnemy = 1;
    [SerializeField] private float lostRange;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float maxRange;
    [SerializeField] private float attackRadius;
    [SerializeField] private float minRange;

    void Start() 
    {
        currentState = EnemyState2.idle;
        enemyAnimator = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        //if(currentState == EnemyState.idle)
        //{
        //    enemyAnimator.SetBool("isWalking", false);
        //}
        //else if(currentState == EnemyState.walk)
        //{
        //    enemyAnimator.SetBool("isWalking", true);
        //    Vector3 temp = Vector3.MoveTowards(transform.position, PlayerMovement.instance.transform.position, speedEnemy * Time.deltaTime);
        //    enemyRigidbody.MovePosition(temp);
        //}

        if(Vector3.Distance(transform.position, enemyTarget.position) <= maxRange &&
            Vector3.Distance(transform.position, enemyTarget.position) >= minRange)
        {
            FollowPlayer();
        }
        else if(Vector3.Distance(transform.position, enemyTarget.position) >= lostRange)
        {
            GoHome();
        }
        else
        {
            enemyAnimator.SetFloat("moveX", (enemyTarget.position.x - transform.position.x));
            enemyAnimator.SetFloat("moveY", (enemyTarget.position.y - transform.position.y));
        }
    }

    public void FollowPlayer()
    {
        enemyAnimator.SetBool("walking", true);
        enemyAnimator.SetFloat("moveX", (enemyTarget.position.x - transform.position.x));
        enemyAnimator.SetFloat("moveY", (enemyTarget.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, enemyTarget.position, speedEnemy * Time.deltaTime);
    }

    public void GoHome()
    {
        enemyAnimator.SetFloat("moveX", (enemyHomePosition.position.x - transform.position.x));
        enemyAnimator.SetFloat("moveY", (enemyHomePosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, enemyHomePosition.position, speedEnemy * Time.deltaTime);

        if(Vector3.Distance(transform.position, enemyHomePosition.position) <= 0.01f)
        {
            enemyAnimator.SetBool("walking", false);
        }
    }
}

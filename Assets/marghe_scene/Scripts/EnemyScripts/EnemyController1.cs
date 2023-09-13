using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{
    [Header("Enemy Stats")]
    public string enemyName;


    [Header("Enemy Movement")]
    private Animator myAnim;
    private Transform target;
    public float speed = 1f;
    public float walkRange = 4f;
    public float attackRange = 2f;
    public Transform homePosition;
    public GameObject playerHealth;
    

    void Start() 
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update() 
    {
        if(Vector3.Distance(transform.position, target.position) <= walkRange && Vector3.Distance(transform.position, target.position) > attackRange)
        {
            myAnim.SetBool("walking", true);
            FollowPlayer();

            if(Vector3.Distance(transform.position, target.position) <= attackRange) //&& Vector3.Distance(transform.position, target.position) >= minRange
            {
                myAnim.SetBool("attacking", true);
                AttackPlayer();
            }

        }
        else if(Vector3.Distance(transform.position, target.position) >= walkRange)
        {
            myAnim.SetBool("walking", true);
            ReturnHomePosition();
        }
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("walking", true);
        myAnim.SetFloat("moveX", (transform.position.x - target.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void AttackPlayer()
    {
        //Debug.Log("Attacking");
        //myAnim.SetBool("walking", false);
        myAnim.SetBool("attacking", true);
        myAnim.SetFloat("moveX", (transform.position.x - target.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void ReturnHomePosition()
    {
        myAnim.SetBool("walking", true);
        myAnim.SetBool("attacking", false);
        myAnim.SetFloat("moveX", (transform.position.x - homePosition.position.x));
        myAnim.SetFloat("moveY", (homePosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);

        if(transform.position == homePosition.position)
        {
            myAnim.SetBool("walking", false);
            myAnim.SetBool("attacking", false);
            myAnim.SetFloat("moveX", (transform.position.x - target.position.x));
            myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        }
    }

    public void Die()
    {
        myAnim.SetBool("died", true);
        myAnim.SetFloat("moveX", (transform.position.x - target.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Enemy Stats")]
    public string enemyName;


    [Header("Enemy Movement")]
    private Animator myAnim;
    private Transform target;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float walkRange = 2f;
    //[SerializeField] private float minRange = 0.5f;
    [SerializeField] private float attackRange = 1f;
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
            FollowPlayer();

            if(Vector3.Distance(transform.position, target.position) <= attackRange) //&& Vector3.Distance(transform.position, target.position) >= minRange
            {
                AttackPlayer();
            }

        }
        else if(Vector3.Distance(transform.position, target.position) >= walkRange)
        {
            ReturnHomePosition();
        }
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("walk", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void AttackPlayer()
    {
        //Debug.Log("Attacking");
        //myAnim.SetBool("walk", false);
        myAnim.SetBool("attack", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void ReturnHomePosition()
    {
        myAnim.SetBool("walk", true);
        myAnim.SetBool("attack", false);
        myAnim.SetFloat("moveX", (homePosition.position.x - transform.position.x
        ));
        myAnim.SetFloat("moveY", (homePosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);

        if(transform.position == homePosition.position)
        {
            myAnim.SetBool("walk", false);
            myAnim.SetBool("attack", false);
            myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
            myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        }
    }
}

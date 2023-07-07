using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float walkRange = 2f;
    [SerializeField] private float minRange = 0.5f;
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
        if(Vector3.Distance(transform.position, target.position) <= walkRange && Vector3.Distance(transform.position, target.position) >= attackRange)
        {
            FollowPlayer();
        }
        else if(Vector3.Distance(transform.position, target.position) <= attackRange && Vector3.Distance(transform.position, target.position) >= minRange)
        {
            AttackPlayer();
        }
        else if(Vector3.Distance(transform.position, target.position) >= walkRange)
        {
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
        Debug.Log("Attacking");
        myAnim.SetBool("walking", false);
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
}

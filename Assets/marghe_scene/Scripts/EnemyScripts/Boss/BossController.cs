using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Boss Stats")]
    public string enemyName;


    [Header("Boss Movement")]
    private Animator myAnim;
    private Transform target;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float walkRange = 3f;
    [SerializeField] private float attackRange = 1f;
    public Transform homePosition;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
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
        myAnim.SetBool("attack", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
    }

    public void ReturnHomePosition()
    {
        myAnim.SetBool("walk", true);
        myAnim.SetFloat("moveX", (homePosition.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePosition.transform.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, homePosition.position) <= 0.1f)
        {
            myAnim.SetBool("walk", false);
            myAnim.SetBool("attack", false);
            myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
            myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        }
    }

    public void Die() 
    {
        myAnim.SetBool("died", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePosition;
    [SerializeField] private float speed;
    [SerializeField] private float lostRange;
    [SerializeField] private float maxRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float minRange;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {


        if(Vector3.Distance(transform.position, target.position) <= maxRange && Vector3.Distance(transform.position, target.position) >= minRange)
        {
            FollowPlayer();
        }
        else if(Vector3.Distance(transform.position, target.position) >= lostRange)
        {
            GoHome();
        }
        else
        {
            myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
            myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        }
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("walking", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        myAnim.SetFloat("moveX", (homePosition.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, homePosition.position) <= 0.01f)
        {
            myAnim.SetBool("walking", false);
        }
    }
}

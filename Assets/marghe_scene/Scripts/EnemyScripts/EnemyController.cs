using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePosition;
    [SerializeField] private float speed;
    [SerializeField] private float maxRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float minRange;
    [SerializeField] private float lostRange;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
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
    }

    public void FollowPlayer()
    {
        if(Vector3.Distance(transform.position, target.position) <= maxRange && Vector3.Distance(transform.position, target.position) >= minRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            myAnim.SetBool("walking", true);
            myAnim.SetFloat("moveX", target.position.x - transform.position.x);
            myAnim.SetFloat("moveY", target.position.y - transform.position.y);

        }
        else
        {
            myAnim.SetBool("walking", false);
            myAnim.SetFloat("moveX", target.position.x - transform.position.x);
            myAnim.SetFloat("moveY", target.position.y - transform.position.y);
        }

        if(Vector3.Distance(transform.position, target.position) >= lostRange)
        {
            GoHome();
        }
    }

    public void GoHome() 
    {
        transform.position = Vector3.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);
        myAnim.SetBool("walking", true);
        myAnim.SetFloat("moveX", homePosition.position.x - transform.position.x);
        myAnim.SetFloat("moveY", homePosition.position.y - transform.position.y);

        if(Vector3.Distance(transform.position, homePosition.position) <= 0.1f)
        {
            myAnim.SetBool("walking", false);
        }
    }
}

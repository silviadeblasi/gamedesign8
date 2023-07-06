using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float walkRange = 2f;
    //[SerializeField] private float attackRange = 1f;
    

    void Start() 
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update() 
    {
        if(Vector3.Distance(transform.position, target.position) <= walkRange)
        {
            FollowPlayer();
        }
        
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("walking", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}

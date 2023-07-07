using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_walk : StateMachineBehaviour
{
    public float speed;
    public float attackRange;
    public float followRange;
    Transform player;
    Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(player.position, rb.position) <= followRange && Vector3.Distance(player.position, rb.position) > attackRange)
        {
            Vector3 target = new Vector3(player.position.x, player.position.y);
            animator.SetFloat("moveX", player.position.x - animator.transform.position.x);
            animator.SetFloat("moveY", player.position.y - animator.transform.position.y);
            Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        else if(Vector3.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("attack");
        }
        // else if(Vector3.Distance(player.position, rb.position) > followRange)
        // {
        //     animator.SetBool("idle", true);
        // }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("attack");
    //    animator.SetBool("idle", false);
    }
}

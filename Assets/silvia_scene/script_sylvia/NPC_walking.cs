using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum NPCstate{
        idle, 
        walk,
        interact
    }*/
public class NPC_walking : MonoBehaviour
{
    //public NPCstate currentState;
    private Rigidbody2D NPCrigidbody;
    [SerializeField] public float speed;
    public float maxdistance = 3;
    [SerializeField] private float range;
    private Animator anim;
    //public AudioSource footsteps;
    Vector2 waypoint;
    void Start(){
        //currentState = NPCstate.walk;
        anim = GetComponent<Animator>();
        NPCrigidbody = GetComponent<Rigidbody2D>();
        //footsteps.enabled = false;
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
        if(waypoint.x > transform.position.x){
            anim.SetFloat("moveX", 1);
            anim.SetFloat("moveY", 0);
        }
        if(waypoint.x < transform.position.x){
            anim.SetFloat("moveX", -1);
            anim.SetFloat("moveY", 0);
        }
        if(waypoint.y > transform.position.y){
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", 1);
        }
        if(waypoint.y < transform.position.y){
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", -1);
        }

        if(Vector2.Distance(transform.position, waypoint) < range){
            SetNewDestination();
        }
    }
    
    void SetNewDestination(){
        waypoint = new Vector2(Random.Range(-maxdistance, maxdistance), Random.Range(-maxdistance, maxdistance));
        maxdistance = Vector2.Distance(transform.position, waypoint);
    }

}

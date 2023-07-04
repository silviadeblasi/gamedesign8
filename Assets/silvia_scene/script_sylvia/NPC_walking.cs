using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_walking : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float maxdistance;
    [SerializeField]
    private float range;

    Vector2 waypoint;
    void Start(){
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, waypoint) < range){
            SetNewDestination();
        }
    }
    
    void SetNewDestination(){
        waypoint = new Vector2(Random.Range(-maxdistance, maxdistance), Random.Range(-maxdistance, maxdistance));
        maxdistance = Vector2.Distance(transform.position, waypoint);
    }
}

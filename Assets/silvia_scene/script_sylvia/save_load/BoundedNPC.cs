using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : MonoBehaviour {
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed; 
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;

    private void Start() {
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    private void Update() {
        Move();
    }
    private void Move(){
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if(bounds.bounds.Contains(temp)){
            myRigidbody.MovePosition(temp);
        }else{
            ChangeDirection();
        }
        
    }

    void ChangeDirection(){
        int direction = Random.Range(0,4);
        switch(direction){
            case 0 : 
                //walking to the right
                directionVector = Vector3.right;
                break;
            case 1 :
                //walking up
                directionVector = Vector3.up;
                break;
            case 2 : 
                //walking to the left
                directionVector = Vector3.left;
                break;
            case 3 :
                //walking down
                directionVector = Vector3.down;
                break;
            default : 
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation(){
        anim.SetFloat("moveX", directionVector.x);
        anim.SetFloat("moveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Vector3 tempo = directionVector;
        ChangeDirection();
        int loops = 0;
        while(tempo == directionVector && loops < 100){
            loops++;
            ChangeDirection();
        }
    }
}

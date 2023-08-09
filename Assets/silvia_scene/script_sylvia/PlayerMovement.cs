using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    idle,
    walk,
    attack,
    run,
    interact,
    stagger,
    dead
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    private float speed = 4;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    //DON'T DELETE THIS COMMENTED CODE
    //Health: first version of health system
    /*public FloatValue currentHealth;
    public Signal playerHealthSignal; */

    //Audio 
    public AudioSource footsteps;
    public AudioSource machete1;
    public vector_value starting_position; //scriptable object per salvare la posizione del player
    public GameObject projectile;
    public AudioSource shotgunSound;
    public Signal reduceShots;
    public ShotgunsBar CurrentShots;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        footsteps.enabled = false;
        machete1.enabled = false;
        shotgunSound.enabled = false;
        transform.position = starting_position.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)  //spacebar
        {
            StartCoroutine(AttackCo());
        } 
        else if (Input.GetButtonDown("shotgun") && currentState != PlayerState.attack && currentState != PlayerState.stagger)  //g
        {
            StartCoroutine(ShotgunCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle || currentState == PlayerState.run) 
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo() 
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        machete1.enabled = true;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f); 
        machete1.enabled = false;
        currentState = PlayerState.walk;
    }

        private IEnumerator ShotgunCo() 
    {
        currentState = PlayerState.attack;
        shotgunSound.enabled = true;
        yield return null;
        MakeShotgun();
        yield return new WaitForSeconds(.3f); 
        shotgunSound.enabled = false;
        currentState = PlayerState.walk;
    }

    private void MakeShotgun()
    {
        if(CurrentShots.currentShots > 0)
        {
            Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            Shotgun shotgun = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Shotgun>();
            shotgun.Setup(temp, ShotgunDirection());
            reduceShots.Raise();
        }
    }

    Vector3 ShotgunDirection ()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    void UpdateAnimationAndMove(){
        if(change != Vector3.zero){
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            footsteps.enabled = true;
        } else {
            animator.SetBool("moving", false);
            footsteps.enabled = false;
        }
        if(change != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
            currentState = PlayerState.run;
            animator.SetBool("run", true);
            speed = 8;
        } else {
            currentState = PlayerState.walk;
            animator.SetBool("run", false);
            speed = 4;
        }
    }

    void MoveCharacter(){
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

    public void Knock(float knockTime, float damage)
    {
        StartCoroutine(KnockCo(knockTime)); //Health: second version of health system
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if(myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    //funzione per riprodurre suono passi
    /*void Footstepsound(){
        footsteps.Play();
    }*/
}

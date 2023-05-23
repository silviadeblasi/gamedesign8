using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonaggio : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Gestiamo all'interno di questa funzione gli INPUT
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Gestiamo all'interno di questa funzione i MOVIMENTI
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
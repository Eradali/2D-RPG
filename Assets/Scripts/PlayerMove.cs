using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
     Vector2 moveInput;
    [SerializeField] InputActionReference move;
    [SerializeField] Animator animator;

    public static PlayerMove instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    }
    private void Move()
    {
        moveInput = move.action.ReadValue<Vector2>();
        //if condition is for player facing that direction where it stop its move for animation
       
         if (moveInput != Vector2.zero)
        {
            animator.SetFloat("Xmove", moveInput.x);
            animator.SetFloat("Ymove", moveInput.y);
            animator.SetBool("isWalking", true);
        }
      
        else 
        {
            animator.SetBool("isWalking", false);
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 lookVector = Vector2.down;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    private Animator anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("Horizontal", lookVector.x);
        anim.SetFloat("Vertical", lookVector.y);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveVector * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        if (moveVector.magnitude > 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 lookVector = context.ReadValue<Vector2>();
        if (lookVector.magnitude == 0)
        {
            return;
        }
        anim.SetFloat("Horizontal", lookVector.x);
        anim.SetFloat("Vertical", lookVector.y);
    }
}

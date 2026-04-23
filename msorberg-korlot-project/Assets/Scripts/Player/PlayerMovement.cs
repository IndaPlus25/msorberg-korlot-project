using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 lookVector = Vector2.down;
    public Vector2 pausedLookVector;
    private Rigidbody2D rb;
    public Vector2 moveVector;
    public Vector2 pausedMoveVector;
    private Animator anim;
    public bool canMove = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SetLook(lookVector);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveVector * moveSpeed;
    }


    public void Move(InputAction.CallbackContext context)
    {
        if (canMove)
        {
            moveVector = context.ReadValue<Vector2>();
        }
        else
        {
            pausedMoveVector = context.ReadValue<Vector2>();
        }
        if (moveVector.magnitude > 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    
    public void StopMovement()
    {
        anim.SetBool("IsWalking", false);
        pausedMoveVector = moveVector;
        pausedLookVector = lookVector;
        moveVector = Vector2.zero;
        canMove = false;
    }

    public void ContinueMovement()
    {
        canMove = true;
        moveVector = pausedMoveVector;
        SetLook(pausedLookVector);
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
        SetLook(lookVector);
    }

    public void SetLook(Vector2 lookVector)
    {
        if (canMove)
        {
            anim.SetFloat("Horizontal", lookVector.x);
            anim.SetFloat("Vertical", lookVector.y);
        }
        else
        {
            pausedLookVector = lookVector;
        }
    }
}

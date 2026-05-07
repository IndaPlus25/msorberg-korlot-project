using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, ICameraLook
{
    public float moveSpeed = 5f;
    public Vector2 lookVector = Vector2.down;
    public Vector2 bufferedLookVector;
    private Rigidbody2D rb;
    public Vector2 moveVector;
    public Vector2 pausedMoveVector;
    private Animator anim;
    public bool canMove = true;
    public bool canBufferLook = false;
    
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
        bufferedLookVector = lookVector;
        moveVector = Vector2.zero;
        canMove = false;
    }

    public void ContinueMovement()
    {
        canMove = true;
        canBufferLook = false;
        moveVector = pausedMoveVector;
        SetLook(bufferedLookVector);
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
        Vector2 newLookVector = context.ReadValue<Vector2>();
        SetLook(newLookVector);
    }


    public void SetLook(Vector2 newLookVector)
    {
        if (newLookVector.magnitude == 0)
        {
            return;
        }
        if (canMove)
        {
            lookVector = newLookVector;
            anim.SetFloat("Horizontal", lookVector.x);
            anim.SetFloat("Vertical", lookVector.y);
        }
        else if (canBufferLook)
        {
            bufferedLookVector = newLookVector;
        }
    }

    public Vector2 GetLookDirection()
    {
        return lookVector;
    }
}

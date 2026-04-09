using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;
    float desiredRotation = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack"))
        {
            transform.localEulerAngles = new Vector3(0, 0, -desiredRotation);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput.x == 0 && moveInput.y != 0)
        {
            anim.SetBool("WalkingDown", true);
        }
        else if (moveInput.x != 0)
        {
            anim.SetBool("WalkingDown", false);
            if (moveInput.x > 0)
            {
                transform.localEulerAngles = new Vector3(0, 90, 0);
            }
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 lookVector = context.ReadValue<Vector2>();
        if (lookVector.x == 0 && lookVector.y == 0)
        {
            return;
        }
        desiredRotation = Mathf.Atan2(lookVector.x, lookVector.y) * Mathf.Rad2Deg;
    }
}

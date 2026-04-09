using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;
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
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Look(InputAction.CallbackContext context)
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack"))
        {
            Vector2 lookVector = context.ReadValue<Vector2>();
            if (lookVector.x == 0 && lookVector.y == 0)
            {
                return;
            }
            float rotation = Mathf.Atan2(lookVector.x, lookVector.y) * Mathf.Rad2Deg;
            transform.localEulerAngles = new Vector3(0, 0, -rotation);
        }
    }
}

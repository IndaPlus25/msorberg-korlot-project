using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    //public Player pc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Move(Vector2 direction, float speed)
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    public void UpdateLookDirection(Vector2 direction)
    {
        if (direction == Vector2.zero) return;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            anim.SetFloat("Horizontal", Mathf.Sign(direction.x));
            anim.SetFloat("Vertical", 0);
        }
        else
        {
            anim.SetFloat("Horizontal", 0);
            anim.SetFloat("Vertical", Mathf.Sign(direction.y));
        }
    }

    public void Stop()
    {
        rb.linearVelocity = Vector2.zero;

    }
        public void Attack()
    {
        anim.SetTrigger("Attack");
    }


}
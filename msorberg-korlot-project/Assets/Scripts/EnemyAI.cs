using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform attackpoint;
    public LayerMask playerLayer;
    private EnemyStats stats;
    private EnemyMovement movement;
    private float attackTimer = 0;

   public void DealDamage()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position,stats.attackRange,playerLayer);

        if (hit != null)
        {
            Player player = hit.GetComponent<Player>();

            if (player != null && hit.CompareTag("Player"))
            {
                hit.GetComponent<Player>().Hurt(stats.damage);
            }
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stats = GetComponent<EnemyStats>();
        movement = GetComponent<EnemyMovement>();  
    }

    void FixedUpdate()
    {   
        if (attackTimer > 0)
        {
            attackTimer -= Time.fixedDeltaTime;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        float distance = Vector2.Distance(player.position, transform.position);

        if (distance > stats.attackRange)
        {   
            movement.Move(direction, stats.speed);
        }
        else if (attackTimer <=0)
        {
            movement.Stop();
            movement.Attack();
            attackTimer = stats.attackCooldown;

        }
        movement.UpdateLookDirection(direction);
    }
}
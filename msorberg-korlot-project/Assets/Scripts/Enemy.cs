using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public int maxHealth;
    public int health;
    public int mana;
    public float speed;
    public float attackRange;
    public int damage;
    public GameObject player;

    private Animator anim;
    
    
    public void ChangeHp(int change)
    {   
        if (maxHealth >= health + change)
        {
            health += change;  
        }
        else if (maxHealth <= health + change)
        {
            health = maxHealth;
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        anim.GetComponent<Rigidbody2D>();
        
    }

    // FixedUpdate is called 50x Sec
    void FixedUpdate()
    {
        //TODO
        // Implement function to awake
            //Move towards Player
            Vector3 direction = player.transform.position - transform.position;

            if (direction.magnitude > attackRange/2)
                transform.position += direction.normalized * speed * Time.fixedDeltaTime;


            
            //Check proximity to Player
        
    }
}

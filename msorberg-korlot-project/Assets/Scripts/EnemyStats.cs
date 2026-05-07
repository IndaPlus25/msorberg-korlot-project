using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int mana;
    public float speed;
    public float attackRange;
    public int damage;
    public string status;
    public float attackCooldown;


    
    
    public void ChangeHp(int change)
    {   
        health += change;  
        
        //Set health in the range of maxhealth and 0
        health = Mathf.Clamp(health, 0, maxHealth);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

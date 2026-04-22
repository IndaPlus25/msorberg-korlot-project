using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public float meleeSpeed;
    public float damage;
    public bool canMelee = true;
    List<GameObject> enemiesInMeleeRange = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if (canMelee == true)
        {
            anim.SetTrigger("Attack");
            StartCoroutine(WaitAttack());
        }
    }

    IEnumerator WaitAttack()
    {
        canMelee = false;
        yield return new WaitForSeconds(meleeSpeed);
        canMelee = true;
    }

    public void AttackEnemy()
    {
        foreach (GameObject enemy in enemiesInMeleeRange)
        {
            // Attack enemy
            /*
            enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.Hurt(damage);
            */
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInMeleeRange.Add(collision.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInMeleeRange.Remove(collision.gameObject);
        }
    }
}

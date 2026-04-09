using System;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public float meleeSpeed;
    public float damage;
    public bool canMelee = true;
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
        Debug.Log("Can melee? " + canMelee);
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
}

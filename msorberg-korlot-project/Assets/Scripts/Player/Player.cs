using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public bool canBeAttacked = true;
    public float invisFrames = 1.5f;
    public float flashTime = 0.25f;
    public float flashAmount = 0.35f;
    private Material material;

    void Start()
    {
        material = gameObject.GetComponent<SpriteRenderer>().material;
    }

    public void Hurt(int damage)
    {
        if (canBeAttacked == true)
        {
            StartCoroutine(HurtCooldown());
            StartCoroutine(HurtFlash());
            health -= damage;
            if (health <= 0)
            {
                StartCoroutine(Death());
            }
        }
    }

    IEnumerator HurtCooldown()
    {
        canBeAttacked = false;
        yield return new WaitForSeconds(invisFrames);
        canBeAttacked = true;
        material.SetFloat("_FlashAmount", 0);
    }

    IEnumerator HurtFlash()
    {
        material.SetColor("_FlashColor", Color.red);
        material.SetFloat("_FlashAmount", flashAmount);
        yield return new WaitForSeconds(flashTime);
        material.SetFloat("_FlashAmount", 0);
        while(canBeAttacked == false)
        {
            yield return new WaitForSeconds(flashTime);
            material.SetColor("_FlashColor", Color.white);
            material.SetFloat("_FlashAmount", flashAmount/6);
            yield return new WaitForSeconds(flashTime);
            material.SetFloat("_FlashAmount", 0);
        }
    }

    IEnumerator Death()
    {
        material.SetFloat("_FlashAmount", 1);
        material.SetColor("_FlashColor", Color.red);
        yield return new WaitForSeconds(flashTime);
        Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public int enemyHealth = 50;
    // Start is called once before the first execution of Update after the
    // MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {



    }

    void Death()
    {
        if (enemyHealth <= 0 && !isDead)
        {
            isDead = true;
            StartCoroutine(DeathAnimation());
        }
    }
    IEnumerator DeathAnimation()
    {
        animator.SetTrigger("Edead");

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        yield return new WaitForSeconds(1.1f);

        Destroy(gameObject);
    }
    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Sword") || other.CompareTag("Bullet")) && !isDead)
        {
            enemyHealth -= 10;

            if (enemyHealth <= 0)
            {
                isDead = true;
                StartCoroutine(DeathAnimation());
            }
            else
            {
                animator.SetTrigger("Ehurt");
            }
        }
    }
}

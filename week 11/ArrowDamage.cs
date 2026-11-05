using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth =
                collision.GetComponentInParent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.health -= damage;
            }
        }
    }
}

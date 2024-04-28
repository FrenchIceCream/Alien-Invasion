using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    void OnTriggerEnter2D(Collider2D other)
    {
        DealDamage dealDamage = other.GetComponent<DealDamage>();
        if (dealDamage != null)
        {
            TakeDamage(dealDamage.GetDamage());
            dealDamage.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

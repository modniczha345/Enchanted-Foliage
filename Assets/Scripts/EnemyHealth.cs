using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float health = 100; // Добавили поле health
    public float damage = 10; // Уменьшили урон, чтобы не убивать врага с одного удара

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireball();
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage); // Вызываем метод TakeDamage()
        }
    }

    public void TakeDamage(float damage) // Добавили метод TakeDamage()
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
}

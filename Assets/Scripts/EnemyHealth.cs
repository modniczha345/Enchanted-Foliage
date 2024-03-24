using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float health = 400; // Обновить это значение
    public float damage = 10;
    public int experienceValue = 10;
    public PlayerProgress playerProgress;
    public Explosion explosionPrefab;
    public GameObject fireball; // Добавить это поле

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == fireball) // Добавить эту строку
        {
            DealDamage(100); // Добавить эту строку
            DestroyFireball();
        }
        else
        {
            DamageEnemy(collision);
        }
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth == null) // Добавить эту строку
        {
            DealDamage(damage); // Обновить эту строку
        }
    }

    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(experienceValue);

        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void DestroyFireball()
    {
        Destroy(fireball); // Обновить эту строку
    }
}

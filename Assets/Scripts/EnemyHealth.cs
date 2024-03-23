using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float health = 100;
    public float damage = 10;
    public int experienceValue = 10;
    public PlayerProgress playerProgress;
    public Explosion explosionPrefab;

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

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
            enemyHealth.DealDamage(damage); 
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
        Destroy(gameObject);
    }
}

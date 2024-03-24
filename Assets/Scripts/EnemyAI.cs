using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage;
    public float viewDistance; // Add this line
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        NoticePlayerUpdate();
        if (_isPlayerNoticed)
        {
            ChasePlayer();
        }
        else
        {
            PatrolUpdate();
        }
        AttackUpdate();
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle && direction.magnitude <= viewDistance) // Update this line
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            PickNewPatrolPoint();
        }
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void ChasePlayer()
    {
        _navMeshAgent.destination = player.transform.position;
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }
}

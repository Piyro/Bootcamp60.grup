using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npc2 : MonoBehaviour
{
    NavMeshAgent _agent;
    [SerializeField] Transform _player;
    [SerializeField] LayerMask groundLayer, playerLayer;
    [SerializeField] Vector3 destinationPoint;

    [SerializeField] bool setDestinationPoint;
    [SerializeField] float walkPointRange;
    [SerializeField] float sightRange, attackRange;
    [SerializeField] bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    void Patroling()
    {
        if (!setDestinationPoint)
        {
            SearchWalkPoint();
        }
        if (setDestinationPoint)
        {
            _agent.SetDestination(destinationPoint);
        }
        Vector3 distanceToDestinationPoint = transform.position - destinationPoint;
        if (distanceToDestinationPoint.magnitude < 1)
        {
            setDestinationPoint = false;
        }
    }
    void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        destinationPoint = new Vector3(transform.position.x + randomX,
            transform.position.y,
            transform.position.z + randomZ);

        if (Physics.Raycast(destinationPoint, -transform.up, 2.0f, groundLayer))
        {
            setDestinationPoint = true;
        }
    }
    void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }
    void AttackPlayer()
    {
        _agent.SetDestination(transform.position);

        transform.LookAt(_player);
    }
    private IEnumerator ChangeBulletTag(GameObject _bullet)
    {
        yield return new WaitForSeconds(2);
        _bullet.tag = "Untagged";
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Entity
{
    //variables
    public float expVal;
    private PlayerStats playerStat;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //for patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timebetweenAttacks;
    bool alreadyAttacked;
    public Gun gun;
    public Transform eHandHold;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player Holder").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //site and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //reached walkpoint
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        //calculates random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //enemy stops moving to attack
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //shooting code
            gun.ShootContinuous();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timebetweenAttacks);
        }

    }



    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void Start()
    {
        gun.transform.parent = eHandHold;
        playerStat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public override void Die()
    {
        playerStat.AddExperience(expVal);//gives player exp on death
        base.Die();
    }
}

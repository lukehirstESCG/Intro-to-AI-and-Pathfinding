using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementSM : MonoBehaviour
{
    public Transform target;
    public Transform enemy;
    public Animator anim;
    public NavMeshAgent agent;
    public float targetDist;

    public enemyIdle enemyIdleState;
    public enemyAttacking enemyAttackState;

    public EnemyStateMachine esm;

    public void Start()
    {
        esm = gameObject.AddComponent<EnemyStateMachine>();

        enemyIdleState = new enemyIdle(this, esm);
        enemyAttackState = new enemyAttacking(this, esm);
    }

    public void Update()
    {
        ChasePlayer();
        AttackPlayer();
    }

    public void ChasePlayer()
    {
        agent.SetDestination(target.position);
    }

    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(target);
    }
}

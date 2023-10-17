using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementSM : StateMachine
{
    public Transform target;
    public Transform enemy;
    public Animator anim;
    public NavMeshAgent agent;
    public float targetDist;
    public float timer = 5;
    public Pathfinding pf;

    [HideInInspector]
    public enemyIdle idleState;
    [HideInInspector]
    public enemyAttacking attackingState;

    private void Awake()
    {
        idleState = new enemyIdle(this);
        attackingState = new enemyAttacking(this, pf);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}

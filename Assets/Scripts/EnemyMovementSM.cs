using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementSM : StateMachine
{
    // Makes the transform of the target public.
    public Transform target;
    // Makes the transform of the enemy public.
    public Transform enemy;
    // Makes the animator component public.
    public Animator anim;
    // Makes the agent component public.
    public NavMeshAgent agent;
    // Makes the targetDist float public.
    public float targetDist;
    // Sets the timer to 5.
    public float timer = 5;
    // Makes the Pathfinding script variable public.
    public Pathfinding pf;
    // Makes the attacked bool public.
    public bool attacked;

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

    public void ResetTimer()
    {
        // Initially set the timer to 5.
        timer = 5;
    }
}

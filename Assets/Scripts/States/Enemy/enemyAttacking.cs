using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttacking : BaseState
{
    private EnemyMovementSM sm;

    public enemyAttacking(EnemyMovementSM stateMachine) : base("Attacking", stateMachine)
    {
        sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // If the player is more then 10 m away...
        if (sm.targetDist > 10)
        {
            stateMachine.ChangeState(sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        // Move the agent to the target destination.
        sm.agent.SetDestination(sm.target.position);

        float distToplayer = Vector3.Distance(sm.enemy.transform.position, sm.target.position);

        float closeDist = 2;

        // Is the enemy next to the player?
        if (distToplayer <= closeDist)
        {
            sm.agent.SetDestination(sm.transform.position);

            // Look at the player.
            sm.enemy.transform.LookAt(sm.target);

            sm.targetDist = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttacking : BaseState
{
    private EnemyMovementSM sm;

    private PlayerMovementSM psm;

    public enemyAttacking(EnemyMovementSM stateMachine) : base("Attacking", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        sm.targetDistance = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // If the player is more then 10 m away...
        if (sm.targetDistance > 10)
        {
            stateMachine.ChangeState(sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        // Move the agent to the target destination.
        sm.agent.SetDestination(sm.target.position);

        // Is the enemy next to the player?
        if (sm.enemy.transform.position == sm.target.position)
        {
            // Stop the agent from moving
            sm.agent.SetDestination(sm.enemy.transform.position);

            // Look at the player.
            sm.enemy.transform.LookAt(psm.Player);

            sm.targetDistance = 0;
        }
    }
}

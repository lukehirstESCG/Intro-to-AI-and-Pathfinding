using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAttacking : BaseState
{
    private EnemyMovementSM sm;

    private Pathfinding pf;

    public enemyAttacking(EnemyMovementSM stateMachine, Pathfinding pathfinding) : base("Attacking", stateMachine)
    {
        sm = stateMachine;
        pf = pathfinding;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // If the player is more then 2 m away or if the timer is zero.
        if (sm.targetDist > 2 || sm.timer <= 0)
        {
            // Initial attack.
            if (sm.attacked != true)
            {
                sm.timer = 0;
                stateMachine.ChangeState(sm.idleState);
                sm.anim.SetBool("attacking", false);
                sm.anim.SetBool("walk", true);
                sm.attacked = true;
                Debug.Log("IDLE!");
            }
            // The next attack.
            else if (sm.attacked == true)
            {
                sm.ResetTimer();
                stateMachine.ChangeState(sm.idleState);
                sm.anim.SetBool("attacking", false);
                sm.anim.SetBool("walk", true);
                sm.attacked = false;
                Debug.Log("IDLE!");
            }
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        // Move the agent to the target destination.
        sm.agent.SetDestination(sm.target.position);

        sm.targetDist = Vector3.Distance(sm.enemy.transform.position, sm.target.transform.position);

        float closeDist = 1;

        // Is the enemy next to the player?
        if (sm.targetDist < closeDist)
        {
            sm.agent.SetDestination(sm.transform.position);

            // Look at the player.
            sm.enemy.transform.LookAt(sm.target);
            sm.agent.isStopped = true;
            sm.anim.SetBool("walk", false);

            sm.targetDist = 0;

            sm.timer -= Time.deltaTime;

            if (sm.timer <= 0 && sm.attacked == true)
            {
                sm.timer = 0;
                sm.agent.isStopped = false;
                pf.GoToNextPoint();
                sm.anim.SetBool("attacking", false);
                sm.anim.SetBool("walk", true);
                sm.attacked = false;
            }
            else if (sm.attacked != true)
            {
                sm.attacked = true;
                sm.agent.isStopped = true;
                sm.anim.SetBool("attacking", true);
                sm.anim.SetBool("walk", true);
            }

        }
    }
}
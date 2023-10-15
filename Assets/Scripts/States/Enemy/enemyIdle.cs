using UnityEngine;

public class enemyIdle : BaseState
{
    public enemyIdle(EnemyMovementSM stateMachine) : base("Idle", stateMachine)
    {
        sm = stateMachine;
    }

    private EnemyMovementSM sm;

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        float closeDist = 2f;

        float dist = Vector3.Distance(sm.enemy.transform.position, sm.target.position);

        if (dist <= closeDist)
        {
            stateMachine.ChangeState(sm.attackingState);

            sm.anim.SetBool("attacking", true);
        }
    }
}

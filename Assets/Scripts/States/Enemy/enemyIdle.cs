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

        float closeDist = 1f;

        float dist = Vector3.Distance(sm.enemy.transform.position, sm.target.position);

        if (dist < closeDist && sm.timer > 0)
        {
            sm.timer = 5;
            stateMachine.ChangeState(sm.attackingState);
            sm.anim.SetBool("attacking", true);
        }
    }
}

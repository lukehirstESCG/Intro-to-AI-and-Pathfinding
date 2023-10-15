using UnityEngine;

public class enemyIdle : BaseState
{
    public enemyIdle(EnemyMovementSM stateMachine) : base("Idle", stateMachine) { }

    private EnemyMovementSM sm;

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (sm.enemy.transform.position == sm.target.position)
        {
            stateMachine.ChangeState(sm.attackingState);

            sm.anim.SetBool("attacking", true);
        }
    }
}

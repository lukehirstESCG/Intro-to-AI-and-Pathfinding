using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWalking : BaseState
{
    public enemyWalking(EnemyMovementSM stateMachine) : base("Walking", stateMachine)
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState
{
    protected EnemyStateMachine esm;
    protected EnemyMovementSM enemy;

    protected EnemyBaseState(EnemyMovementSM enemy, EnemyStateMachine esm)
    {
        this.esm = esm;
        this.enemy = enemy;
    }

    public virtual void Enter() { }
    public virtual void HandleInput() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}

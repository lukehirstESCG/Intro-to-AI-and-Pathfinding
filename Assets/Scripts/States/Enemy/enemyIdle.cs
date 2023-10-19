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
        sm.ResetTimer();
        sm.attacked = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        float closeDist = 1f;

        // Move the enemy to the target's position.
        float dist = Vector3.Distance(sm.enemy.transform.position, sm.target.position);

        if (dist <= closeDist)
        {
            // Have we not already attacked?
            if (sm.attacked != true && sm.timer > 0)
            {
                // Sets the timer to 5, changes the state to attacking, sets the animation bool to true, and sets the attacked bool to false.
                sm.timer -= Time.deltaTime;
                sm.attacked = false;
                stateMachine.ChangeState(sm.attackingState);
                sm.anim.SetBool("attacking", true);
                Debug.Log("ATTACKING!");
            }
            // Not the initial attack.
            else if (sm.attacked == false && sm.timer < 0)
            {
                // Reset the timer, keep the state at idle, set the animation bool to false, and set the attacked bool to true.
                sm.ResetTimer();
                stateMachine.ChangeState(sm.attackingState);
                sm.anim.SetBool("attacking", true);
                sm.attacked = true;
                Debug.Log("STILL IDLE!");
            }
        }
    }
}
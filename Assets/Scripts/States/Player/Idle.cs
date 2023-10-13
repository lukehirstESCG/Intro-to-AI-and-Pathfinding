using UnityEngine;

public class Idle : BaseState
{
    public Idle(PlayerMovementSM sm) : base("Idle", sm) { }

    private float horizontalInput;

    public override void Enter()
    {
        base.Enter();
        {
            horizontalInput = 0;
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            if (Mathf.Abs(horizontalInput) > Mathf.Epsilon)
            {
                sm.ChangeState(sm.walkingState);
                sm.anim.SetBool("walk", true);
            }
        }
    }
}

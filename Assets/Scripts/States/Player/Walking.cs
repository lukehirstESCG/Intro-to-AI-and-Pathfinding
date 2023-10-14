using UnityEngine;

public class Walking : Grounded
{
    public Walking(PlayerMovementSM stateMachine) : base("Walking", stateMachine) { }

    private float horizontalInput;

    public override void Enter()
    {
        base.Enter();
        horizontalInput = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontalInput) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(sm.idleState);
            // sm.anim.SetBool("walking", false);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = sm.rb.velocity;
        vel.x = horizontalInput * ((PlayerMovementSM)stateMachine).speed;
        sm.rb.velocity = vel;
    }
}

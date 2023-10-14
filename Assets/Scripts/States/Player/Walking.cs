using UnityEngine;

public class Walking : Grounded
{
    public Walking(PlayerMovementSM stateMachine) : base("Walking", stateMachine) { }

    private float horizontalInput;
    private float verticalInput;

    public override void Enter()
    {
        base.Enter();
        horizontalInput = 0;
        verticalInput = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(horizontalInput) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(sm.idleState);
            // sm.anim.SetBool("walking", false);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector3 vel = sm.rb.velocity;
        vel.x = horizontalInput * ((PlayerMovementSM)stateMachine).speed;
        vel.z = verticalInput * ((PlayerMovementSM)stateMachine).speed;
        sm.rb.velocity = vel;
    }
}

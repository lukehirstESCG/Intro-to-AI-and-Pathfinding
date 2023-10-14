using UnityEngine;

public class Idle : Grounded
{
    public Idle(PlayerMovementSM stateMachine) : base("Idle", stateMachine) { }

    private float horizontalInput;
    private float verticalInput;

    public override void Enter()
    {
        base.Enter();
        horizontalInput = 0f;
        verticalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            if (Mathf.Abs(horizontalInput) > Mathf.Epsilon)
            {
               stateMachine.ChangeState(sm.walkingState);
               // sm.anim.SetBool("walk", true);
            }
        }
    }
}

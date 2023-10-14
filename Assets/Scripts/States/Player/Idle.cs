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
        verticalInput = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Debug.Log("KEY PRESSED");
            if (Mathf.Abs(horizontalInput) > Mathf.Epsilon && Mathf.Abs(verticalInput) > Mathf.Epsilon)
            {
               stateMachine.ChangeState(sm.walkingState);
                Debug.Log("CHANGE STATE");
               // sm.anim.SetBool("walk", true);
            }
        }
    }
}

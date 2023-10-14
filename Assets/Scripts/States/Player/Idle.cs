using UnityEngine;

public class Idle : Grounded
{
    public Idle(PlayerMovementSM stateMachine) : base("Idle", stateMachine) { }

    private float horizontalInput;

    public override void Enter()
    {
        base.Enter();
        horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        {
            horizontalInput = Input.GetAxis("Horizontal");
            Debug.Log("KEY PRESSED");
            if (Mathf.Abs(horizontalInput) > Mathf.Epsilon)
            {
               stateMachine.ChangeState(sm.walkingState);
                Debug.Log("CHANGE STATE");
               // sm.anim.SetBool("walk", true);
            }
        }
    }
}

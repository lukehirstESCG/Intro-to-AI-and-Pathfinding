using UnityEngine;

public class Walking : Grounded
{
    public Walking(PlayerMovementSM stateMachine) : base("Walking", stateMachine)
    {
        sm = stateMachine;
    }

    private PlayerMovementSM sm;

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

        if (Mathf.Abs(horizontalInput) < Mathf.Epsilon && Mathf.Abs(verticalInput) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(sm.idleState);
            sm.anim.SetBool("walk", false);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        sm.rotation = new Vector3(0, Input.GetAxis("Horizontal") * sm.rotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = sm.transform.TransformDirection(move);
        sm.advance.Move(move * sm.speed);
        sm.transform.Rotate(sm.rotation);
    }
}

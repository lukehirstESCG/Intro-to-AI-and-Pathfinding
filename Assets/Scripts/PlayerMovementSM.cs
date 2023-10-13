using UnityEngine;

public class PlayerMovementSM : StateMachine
{
    public float speed = 5f;
    public Animator anim;

    [HideInInspector]
    public Idle idleState;

    private void Awake()
    {
        idleState = new Idle(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSM : StateMachine
{
    public float speed = 5f;
    public Rigidbody rb;
    // public Animator anim;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Walking walkingState;

    private void Awake()
    {
        idleState = new Idle(this);
        walkingState = new Walking(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSM : StateMachine
{
    public float speed = 5f;
    public CharacterController advance;
    public float rotationSpeed;
    public Transform Player;
    public Vector3 rotation;
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

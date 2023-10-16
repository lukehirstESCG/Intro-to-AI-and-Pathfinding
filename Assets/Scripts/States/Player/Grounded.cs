using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : BaseState
{
    protected PlayerMovementSM sm;

    public Grounded(string name, PlayerMovementSM stateMachine) : base(name, stateMachine)
    {
        sm = (PlayerMovementSM)this.stateMachine;
    }
}

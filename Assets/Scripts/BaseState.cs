using UnityEngine;

public class BaseState
{
    protected PlayerMovement player;
    protected StateMachine sm;
    public string name;

    protected BaseState(PlayerMovement player, StateMachine sm)
    {
        this.player = player;
        this.sm = sm;
    }

    public virtual void Enter() { }
    public virtual void HandleInput() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}

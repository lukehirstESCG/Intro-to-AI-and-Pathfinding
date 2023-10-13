using UnityEngine;

public class BaseState
{
    public string name;
    protected StateMachine sm;

    public BaseState(string name, StateMachine sm)
    {
        this.name = name;
        this.sm = sm;
    }

    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}

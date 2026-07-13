using UnityEngine;

public interface IState
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
}

public class BaseState : IState
{
    protected MonoBehaviour mOwner;

    public virtual void OnEnter()
    {
        
    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnExit()
    {

    }

    public void SetOwner(MonoBehaviour _owner)
    {
        mOwner = _owner;
    }
}

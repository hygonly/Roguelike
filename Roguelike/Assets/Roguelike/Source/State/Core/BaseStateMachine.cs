using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine
{
    protected Dictionary<Defines.ObjectState, BaseState> mStates = new Dictionary<Defines.ObjectState, BaseState>();
    protected MonoBehaviour mOwner;
    protected Defines.ObjectState mState;
    protected Defines.StateType mCurrentState;

    public virtual void OnEnter()
    {
        mStates[mState].OnEnter();
    }

    public virtual void OnUpdate()
    {
        mStates[mState].OnUpdate();
    }

    public virtual void OnExit()
    {
        mStates[mState].OnExit();
    }

    public void SetOwner(MonoBehaviour _owner)
    {
        mOwner = _owner;
    }

    public void ExecuteState()
    {
        if (mCurrentState == Defines.StateType.OnEnter)
        {
            OnEnter();
            mCurrentState++;
        }

        if (mCurrentState == Defines.StateType.OnUpdate)
        {
            OnUpdate();
        }

        if (mCurrentState == Defines.StateType.OnExit)
        {
            OnExit();
            mCurrentState++;
        }
    }

    public bool ChangeState(Defines.ObjectState _stateType)
    {
        if (mStates.TryGetValue(_stateType, out var state) == false)
            return false;

        mState = _stateType;
        mCurrentState = Defines.StateType.OnEnter;
        return true;
    }

    public void AddState(Defines.ObjectState _stateType, BaseState _state)
    {
        mStates[_stateType] = _state;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class UnitStateData
{
    public Defines.ObjectState UnitState => mObjectState;
    public BaseState State => mState;

    private Defines.ObjectState mObjectState;
    private BaseState mState;

    public UnitStateData(Defines.ObjectState _objectState, BaseState _state)
    {
        mObjectState = _objectState;
        mState = _state;
    }
}

public class UnitStateMachine : BaseStateMachine
{
    public void Update()
    {
        ExecuteState();
    }

    public void SetStates(List<UnitStateData> _states)
    {
        foreach (var stateData in _states)
            AddState(stateData.UnitState, stateData.State);
    }
}

using UnityEngine;

public abstract class UnitControl : ObjectControl
{
    protected UnitStateData mUnitStateData;
    protected UnitStateMachine mStateMachine;

    protected abstract void InitStateMachine();

}

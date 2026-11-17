using System;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillHandler
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
}

public abstract class SkillHandler : ISkillHandler
{
    protected Defines.EffectActionState mEffectActionState;
    protected bool mAppliedEffect;

    protected HashSet<BaseControl> mAppliedTargets = new HashSet<BaseControl>();
    protected EffectData mEffectData;
    public EffectData GetEffectData => mEffectData;

    public virtual void Reset()
    {
        mEffectActionState = Defines.EffectActionState.None;
        mAppliedEffect = false;
    }

    public void Execute()
    {
        ProgressSkillState();
    }

    protected void ProgressSkillState()
    {
        if (mEffectActionState == Defines.EffectActionState.Enter)
        {
            OnEnter();
            TransitionNextState();
        }

        if (mEffectActionState == Defines.EffectActionState.Update)
        {
            OnUpdate();
        }

        if (mEffectActionState == Defines.EffectActionState.Exit)
        {
            OnExit();
            TransitionNextState();
        }
    }

    public virtual void OnEnter()
    {
        OnAssignedEffectData();
        TransitionNextState();
    }

    public virtual void OnExit()
    {
        try
        {
            Revert();
        }
        finally
        {
            mAppliedTargets.Clear();
        }
    }

    public virtual void OnUpdate()
    {
        
    }

    protected void TransitionNextState() => ++mEffectActionState;

    protected virtual void OnAssignedEffectData() { }

    protected virtual void Apply()
    {
        mAppliedEffect = TryApply();
    }

    protected abstract bool TryApply();
    protected abstract void Revert();
}

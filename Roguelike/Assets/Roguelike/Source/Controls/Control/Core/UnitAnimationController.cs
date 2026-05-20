using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimationController : BaseAnimationController
{
    protected Dictionary<Defines.AnimationEventType, Action> mAnimEvents = new Dictionary<Defines.AnimationEventType, Action>();

    public override void AnimationEventHandler(AnimationEventData evtData)
    {
        if (mAnimEvents.TryGetValue(evtData.EventType, out var callback) == false)
            return;

        callback?.Invoke();
    }

    public void AddAnimationEvent(Defines.AnimationEventType evtType, Action callback)
    {
        if (mAnimEvents.ContainsKey(evtType) == false)
        {
            mAnimEvents.Add(evtType, callback);
        }
        else
        {
            mAnimEvents[evtType] -= callback;
            mAnimEvents[evtType] += callback;
        }
    }

    public void RemoveAnimationEvent(Defines.AnimationEventType evtType)
    {
        if (mAnimEvents.ContainsKey(evtType) == false)
            return;

        mAnimEvents.Remove(evtType);
    }
}
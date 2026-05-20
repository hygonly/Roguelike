using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static Defines;

[Serializable]
public class AnimationEventData
{
    public Defines.ObjectState AniState;
    public AnimationEventType EventType;
    public float Time;
}

public class AnimationData
{
    public string AnimName;
    public Defines.ObjectState State;
}

public abstract class BaseAnimationController : SerializedMonoBehaviour
{
    public Dictionary<string, AnimationData> AnimDatas = new Dictionary<string, AnimationData>();
    public Dictionary<Defines.ObjectState, List<AnimationEventData>> AnimEventDatas = new Dictionary<Defines.ObjectState, List<AnimationEventData>>();

    private Animator mAnimator;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    public void PlayAnimation(string stateName, float normalizedTime = 0.1f)
    {
        if (ContainsAnimationClip(stateName) == false)
            return;

        mAnimator.CrossFade(stateName, normalizedTime);
        TrackAnimationEvents(stateName);
    }

    public async void TrackAnimationEvents(string stateName)
    {
        var info = mAnimator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName(stateName) == false)
        {
            Debug.LogError($"Name miss matching: {stateName}");
            return;
        }

        var animData = GetAnimationData(stateName);
        var evtDatas = GetAnimationEventDatas(animData.State);
        
        int index = 0;
        while (evtDatas.Count > index)
        {
            var evtData = evtDatas[index];
            if (info.normalizedTime >= evtData.Time)
            {
                AnimationEventHandler(evtData);
                index++;
            }

            await UniTask.Yield();
        }
    }

    public List<AnimationEventData> GetAnimationEventDatas(Defines.ObjectState state)
    {
        if (AnimEventDatas.TryGetValue(state, out var value) == false)
            return new List<AnimationEventData>();

        return AnimEventDatas[state].OrderBy(_ => _.Time).ToList();
    }

    public void AddAnimationEvent(AnimationEventData eventData)
    {
        if (AnimEventDatas.ContainsKey(eventData.AniState) == false)
            AnimEventDatas.Add(eventData.AniState, new List<AnimationEventData>());

        AnimEventDatas[eventData.AniState].Add(eventData);
    }

    public AnimationData GetAnimationData(string state) => AnimDatas.GetValueOrDefault(state);

    public AnimationClip FindAnimation(string clipName)
    {
        foreach (var clip in mAnimator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == clipName)
                return clip;
        }

        return null;
    }

    public bool ContainsAnimationClip(string clipName)
    {
        var findIt = FindAnimation(clipName);
        if (findIt.name == clipName)
            return true;

        return false;
    }

    public abstract void AnimationEventHandler(AnimationEventData evtData);
}

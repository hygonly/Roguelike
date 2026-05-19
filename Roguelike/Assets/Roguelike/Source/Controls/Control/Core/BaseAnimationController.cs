using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[Serializable]
public class AnimationEventData
{
    public Defines.CreatureState AniState;
    public string EventName;
    public float Time;
}

public class AnimationData
{
    public string AnimName;
    public Defines.CreatureState State;
}

public abstract class BaseAnimationController : SerializedMonoBehaviour
{
    public Dictionary<string, AnimationData> AnimDatas = new Dictionary<string, AnimationData>();
    public Dictionary<Defines.CreatureState, List<AnimationEventData>> AnimEventDatas = new Dictionary<Defines.CreatureState, List<AnimationEventData>>();

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
    }

    public async void TrackAnimationEvents(string stateName)
    {
        var info = mAnimator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName(stateName) == false)
        {
            Debug.LogError($"Name miss matching: {stateName}");
            return;
        }

        var clip = FindAnimation(stateName);
        if (clip == null)
        {
            Debug.LogError($"Not found clip: {stateName}");
            return;
        }

        int index = 0;
        var animData = AnimDatas[stateName];
        var evtDatas = GetAnimationEventDatas(animData.State);
        while (true)
        {
            if (evtDatas.Count <= index)
                break;

            var time = info.normalizedTime * clip.length;
            var evtData = evtDatas[index];
            if (time >= evtData.Time)
            {
                
                index++;
            }

            await UniTask.Yield();
        }
    }

    public List<AnimationEventData> GetAnimationEventDatas(Defines.CreatureState state)
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

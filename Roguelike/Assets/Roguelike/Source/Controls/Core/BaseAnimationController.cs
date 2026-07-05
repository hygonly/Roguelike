using Cysharp.Threading.Tasks;
using HYG.Collections.Generic;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class AnimationEventData
{
    public Defines.ObjectState AniState;
    public Defines.AnimationEventType EventType;
    public float Time;
}

[Serializable]
public class AnimationData
{
    public string AnimName;
    public Defines.ObjectState State;
}


public abstract class BaseAnimationController : SerializedMonoBehaviour
{
    public SerializedDictionary<string, AnimationData> AnimDatas = new SerializedDictionary<string, AnimationData>();
    public SerializedDictionary<Defines.ObjectState, List<AnimationEventData>> AnimEventDatas = new SerializedDictionary<Defines.ObjectState, List<AnimationEventData>>();

    private Animator mAnimator;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    public void PlayAnimation(string _stateName, float _normalizedTime = 0.1f)
    {
        if (ContainsAnimationClip(_stateName) == false)
            return;

        mAnimator.CrossFade(_stateName, _normalizedTime);
        TrackAnimationEvents(_stateName);
    }

    public async void TrackAnimationEvents(string _stateName, int _maxCount = 100)
    {
        var info = mAnimator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName(_stateName) == false)
        {
            Debug.LogError($"Name miss matching: {_stateName}");
            return;
        }

        var animData = GetAnimationData(_stateName);
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

    public List<AnimationEventData> GetAnimationEventDatas(Defines.ObjectState _state)
    {
        if (AnimEventDatas.TryGetValue(_state, out var value) == false)
            return new List<AnimationEventData>();

        return AnimEventDatas[_state].OrderBy(_ => _.Time).ToList();
    }

    public void AddAnimationEvent(AnimationEventData eventData)
    {
        if (AnimEventDatas.ContainsKey(eventData.AniState) == false)
            AnimEventDatas.Add(eventData.AniState, new List<AnimationEventData>());

        AnimEventDatas[eventData.AniState].Add(eventData);
    }

    public AnimationData GetAnimationData(string _state) => AnimDatas.GetValueOrDefault(_state);

    public AnimationClip FindAnimation(string _clipName)
    {
        foreach (var clip in mAnimator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == _clipName)
                return clip;
        }

        return null;
    }

    public bool ContainsAnimationClip(string _clipName)
    {
        var findIt = FindAnimation(_clipName);
        if (findIt.name == _clipName)
            return true;

        return false;
    }

    public abstract void AnimationEventHandler(AnimationEventData _evtData);
}

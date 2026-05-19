using Sirenix.OdinInspector;
using UnityEngine;

public abstract class ObjectControl : SerializedMonoBehaviour
{
    protected BaseAnimationController animController;

    protected abstract void AnimationEventHandler(AnimationEventData eventData);
}

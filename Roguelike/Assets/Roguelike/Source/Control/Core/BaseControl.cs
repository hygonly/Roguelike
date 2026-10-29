using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public abstract class BaseControl : SerializedMonoBehaviour
{
    protected Defines.CreatureState mState;

    protected virtual void Start()
    {
        Init();
        OnChangeSubscribes();
    }

    protected abstract void Init();
    protected abstract void OnChangeSubscribes();

    protected virtual void FixedUpdate()
    {
        switch (mState)
        {
            case Defines.CreatureState.Dead:
                UpdateDead();
                break;
            case Defines.CreatureState.Idle:
                UpdateIdle();
                break;
            case Defines.CreatureState.Move:
                UpdateMove();
                break;
            case Defines.CreatureState.Skill:
                UpdateSkill();
                break;
            case Defines.CreatureState.Defense:
                UpdateDefense();
                break;
            case Defines.CreatureState.Hit:
                UpdateHit();
                break;
        }
    }

    protected virtual void UpdateIdle() { }
    protected virtual void UpdateMove() { }
    protected virtual void UpdateSkill() { }
    protected virtual void UpdateDefense() { }
    protected virtual void UpdateHit() { }
    protected virtual void UpdateDead() { }

    protected abstract void ChangeState(Defines.CreatureState _creatureState);
}

using Sirenix.OdinInspector;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public partial class PlayerControl : BaseControl
{
    [ReadOnly] private Vector2 mDirection;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Collider2D jumpCollider;
    private bool isGround;

    protected override void Init()
    {
        jumpCollider.OnTriggerEnter2DAsObservable().Subscribe(_other =>
        {

        }).AddTo(this);

        jumpCollider.OnTriggerEnter2DAsObservable().Subscribe(_other =>
        {

        }).AddTo(this);


        ChangeState(Defines.CreatureState.Idle);
    }

    protected override void OnChangeSubscribes()
    {
        BindInputEvents();
    }

    protected override void ChangeState(Defines.CreatureState _creatureState)
    {
        mState = _creatureState;
    }

    protected override void UpdateIdle()
    {
        if (mDirection != Vector2.zero)
        {
            ChangeState(Defines.CreatureState.Move);
        }
    }

    protected override void UpdateMove()
    {
        if (mDirection == Vector2.zero)
        {
            ChangeState(Defines.CreatureState.Idle);
            return;
        }

        mRigidbody.linearVelocityX = mDirection.x * mSpeed;
    }
}

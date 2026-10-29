using Sirenix.OdinInspector;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public partial class PlayerControl : BaseControl
{
    [ReadOnly] private Vector2 mDirection;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private Collider2D jumpCollider;
    private Rigidbody2D mRigidbody;
    private bool isJump;

    protected override void Init()
    {
        jumpCollider.OnTriggerEnter2DAsObservable().Subscribe(_other =>
        {
            if (_other.CompareTag(Config.GROUND_TAG) == true)
                isJump = false;

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

        mRigidbody.linearVelocityX = mDirection.x * speed;
    }

    private void Jump()
    {
        if (isJump == true)
            return;

        mRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
}

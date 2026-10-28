using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UniRx.Triggers;
using UnityEngine;

public abstract class BaseControl : SerializedMonoBehaviour
{
    protected Rigidbody2D mRigidbody;
    protected BoxCollider2D jumpCollider;

    protected virtual void Start()
    {
        jumpCollider.OnTriggerEnter2DAsObservable().Subscribe(_ =>
        {

        }).AddTo(this);

        Init();
        OnChangeSubscribes();
    }

    protected abstract void Init();
    protected abstract void OnChangeSubscribes();

    public virtual void MoveObject(Vector3 _direction, float _speed)
    {
        
    }
}

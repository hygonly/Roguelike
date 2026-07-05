using Sirenix.OdinInspector;
using UnityEngine;
using UniRx;

public abstract class ObjectControl : SerializedMonoBehaviour
{
    private void Awake()
    {
        Initialized();
    }

    private void Start()
    {
        SubscribesChange();
    }

    public abstract void Initialized();
    protected abstract void SubscribesChange();

    public void MoveObjectToTarget(Vector3 targetPos, float _moveSpeed)
    {
        Vector3 ownPos = transform.position;
        bool isTargetOnRight = targetPos.x > 0;

        var direction = isTargetOnRight == true ? Defines.Direction.Right : Defines.Direction.Left;
        SetFlip(direction);

        var dir = (targetPos - ownPos).normalized;
        transform.Translate(dir * _moveSpeed * Time.timeScale);
    }

    public void SetFlip(Defines.Direction _dir)
    {
        var isTargetOnRight = _dir == Defines.Direction.Right;
        var scale = transform.localScale;
        scale.x = isTargetOnRight == true ? 1 : -1;
        transform.localScale = scale;
    }

    public void Return()
    {
        if (this.IsObjectValid() == false)
            return;

        Managers.Pool.Push(gameObject);
    }
}

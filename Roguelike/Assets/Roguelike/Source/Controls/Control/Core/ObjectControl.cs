using Sirenix.OdinInspector;
using UnityEngine;

public abstract class ObjectControl : SerializedMonoBehaviour
{
    //오브젝트 ID
    //활성화/비활성화
    //기본 초기화
    //좌표, 방향 같은 최소 공통값
    //풀링 대상이면 OnSpawn, OnDespawn

    protected Defines.Direction mDir;

    private void Awake()
    {
        Initialized();
    }

    private void Start()
    {
        SubscribeChanges();
    }

    public void Return()
    {
        if (this.IsObjectValid() == false)
            return;

        Managers.Pool.Push(gameObject);
    }

    public abstract void Initialized();
    protected abstract void SubscribeChanges();


    public void ObjectMoveToTarget(Vector3 target, float moveSpeed)
    {
        Vector3 ownPos = transform.position;
        Vector3 dir = (target - ownPos).normalized;

        var isTargetOnRight = dir.x > 0;
        var direction = isTargetOnRight == true ? Defines.Direction.Right : Defines.Direction.Left;
        SetFlip(direction);

        Vector3 moveTraslate = dir * moveSpeed * Managers.Time.DeltaTime;
        transform.Translate(moveTraslate);
    }

    public void SetFlip(Defines.Direction dir)
    {
        if (mDir == dir)
            return;

        var scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (dir == Defines.Direction.Left ? -1f : 1f);

         transform.localScale = scale;
    }

    public abstract void OnChangeState(Defines.ObjectState state);
}

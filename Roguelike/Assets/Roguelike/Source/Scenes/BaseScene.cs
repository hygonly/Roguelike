using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public Defines.SceneType SceneType => mSceneType;

    protected Defines.SceneType mSceneType;

    protected bool mInit;

    private void Awake()
    {
        Init();
    }

    protected virtual bool Init()
    {
        if (mInit == true)
            return false;

        Managers.Scene.RegisterScene(this);
        return true;
    }

    public virtual void Clear()
    {
        if (mInit == false)
            return;

        mInit = false;
        Managers.Scene.UnregisterScene(mSceneType);
    }
}
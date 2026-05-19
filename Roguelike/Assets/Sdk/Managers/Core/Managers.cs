using UnityEngine;

public partial class Managers : HYG.Manager.Base.MasterManager
{
    public static Managers Instance 
    { 
        get 
        {
            if (mInstance == null)
            {
                mInstance = Create();
                mInstance.Init();
                _init = true;
            }

            return mInstance; 
        } 
    }

    private static Managers mInstance;

    private static bool _init;

    private static Managers Create()
    {
        GameObject go = GameObject.Find("@Managers");
        if (go == null)
        {
            go = new GameObject("@Managers");
            go.AddComponent<Managers>();
        }

        DontDestroyOnLoad(go);
        return go.GetComponent<Managers>();
    }
}

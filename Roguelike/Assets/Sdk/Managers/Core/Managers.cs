using UnityEngine;

namespace HYG.Manager.Core
{
    public abstract class Managers<T> : HYG.Manager.Base.MasterManager where T : Managers, new()
    {
        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = Create();
                    Init();
                }

                return mInstance;
            }
        }

        protected static T mInstance;

        protected static bool mInit;

        protected static T Create()
        {
            if (mInstance != null)
                return mInstance;

            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject("@Managers");
                go.AddComponent<T>();
            }

            DontDestroyOnLoad(go);
            T newManager = go.GetComponent<T>();
            return newManager;
        }

        protected static void Init()
        {
            mInstance.InitManager();
            mInit = true;
        }
        public abstract void Clear();
    }
}

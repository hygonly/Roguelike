using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

namespace HYG.Manager.Pool
{
    public class PoolManager : HYG.Manager.Base.SlaveManager
    {
        public class PoolObject
        {
            private GameObject mPrefab;
            private Transform mRoot;
            private string mID;
            private string mKey;
            private IObjectPool<GameObject> mPool;
            private bool mClearPool;
            private int mPopCount;

            public PoolObject(GameObject prefab, Transform root, string id, string key, bool clearPool = true)
            {
                mPrefab = prefab;
                mRoot = root;
                mID = id;
                mKey = key;
                mClearPool = clearPool;
                mPopCount = 0;

                mPool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroy, maxSize: 20);
            }

            private GameObject OnCreate()
            {
                GameObject go = Object.Instantiate(mPrefab, mRoot);
                go.name = $"{mID}";
                return go;
            }

            private void OnGet(GameObject go)
            {
                go.transform.parent = null;
                go.SetActive(true);
            }

            private void OnRelease(GameObject go)
            {
                go.transform.parent = mRoot;
                go.SetActive(false);
            }

            private void OnDestroy(GameObject go)
            {
                Object.Destroy(go);
            }

            public void Push(GameObject go)
            {
                if (go.activeSelf == true)
                    mPool.Release(go);
            }

            public GameObject Pop()
            {
                if (mClearPool == true && mKey.Equals("") == false)
                    Interlocked.Increment(ref mPopCount);

                return mPool.Get();
            }

            public bool ClearPool()
            {
                if (mClearPool == true)
                {
                    mPool.Clear();
                    Managers.Resource.ResourceRelease(mKey, mPopCount);
                }

                return mClearPool;
            }
        }
    }

    public
}

using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

namespace HYG.Manager.Pool
{
    public class GameObjectPool
    {
        private GameObject mPrefab;
        private Transform mRoot;
        private string mID;
        private string mKey;
        private IObjectPool<GameObject> mPool;
        private bool mClearPool;
        private int mPopCount;

        public GameObjectPool(GameObject prefab, Transform root, string id, string key, bool clearPool = true)
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
            {
                go.transform.SetParent(mRoot, false);
                mPool.Release(go);
            }
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

    public class PoolManager : HYG.Manager.Base.SlaveManager
    {
        protected Dictionary<string, GameObjectPool> mPools = new Dictionary<string, GameObjectPool>();

        private Transform mRoot;

        protected override void Init()
        {
            mRoot = new GameObject("@Pool").transform;
            mRoot.transform.SetParent(Managers.Instance.transform);
        }

        public GameObject Pop(GameObject prefab, string uniqueKey, string key, bool clearPool = true)
        {
            if (mPools.TryGetValue(uniqueKey, out GameObjectPool pool) == false)
            {
                Transform root = new GameObject($"{uniqueKey}_Root").transform;
                root.SetParent(mRoot);
                pool = new GameObjectPool(prefab, root, uniqueKey, key, clearPool);
                mPools.Add(uniqueKey, pool);
            }

            GameObject go = pool.Pop();
            go.transform.SetParent(null);
            return go;
        }

        public void Push(GameObject go)
        {
            if (mPools.ContainsKey(go.name) == false)
            {
                Object.Destroy(go);
                return;
            }

            mPools[go.name].Push(go);
        }

        public override void Clear()
        {
            List<string> removeKyes = new List<string>();
            foreach (var pool in mPools)
            {
                if (pool.Value.ClearPool() == true)
                    removeKyes.Add(pool.Key);
            }

            foreach (var key in removeKyes)
            {
                if (mPools.ContainsKey(key) == false)
                    continue;

                mPools.Remove(key);
            }
        }

        public void ClearPool(string id)
        {
            if (mPools.TryGetValue(id, out var pool) == false)
                return;

            pool.ClearPool();
            mPools.Remove(id);
        }

        public void ClearDict()
        {
            mPools.Clear();
        }
    }
}

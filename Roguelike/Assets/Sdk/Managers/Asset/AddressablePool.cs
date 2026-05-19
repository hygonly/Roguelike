using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

public class AddressablePool
{
    [Serializable]
    public class AddressableRef
    {
        public Object resource;
        public int refCount;
        
        public AddressableRef(Object resource)
        {
            this.resource = resource;
        }

    }

    private Dictionary<string, AddressableRef> mAddressableRefDatas = new();
    private HashSet<string> mLoadedDatas = new();
    private HashSet<string> mReleaseDatas = new();
    private List<string> mResourceReleaseDatas = new();

    public async UniTask<T> LoadAddressable<T>(string key) where T : Object
    {
        if (mAddressableRefDatas.ContainsKey(key) == false)
        {
            if (mLoadedDatas.Contains(key) == false)
            {
                try
                {
                    mLoadedDatas.Add(key);
                    var asyncOperation = Addressables.LoadAssetAsync<T>(key);

                    await UniTask.WaitUntil(() => asyncOperation.IsDone == true);

                    mLoadedDatas.Remove(key);
                    if (asyncOperation.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                    {
                        mAddressableRefDatas[key] = new AddressableRef(asyncOperation.Result);
                    }
                    else
                    {
                        mAddressableRefDatas[key] = null;
                        Debug.LogError($"Failed load asset: {key}");
                        return null;
                    }
                }
                catch (Exception)
                {
                    mAddressableRefDatas[key] = null;
                    Debug.LogError($"Failed load asset: {key}");
                    return null;
                }
            }
            else
            {
                await UniTask.WaitUntil(() => mAddressableRefDatas.ContainsKey(key) == true);
            }
        }

        if (mAddressableRefDatas.ContainsKey(key) == false)
            return null;

        Interlocked.Increment(ref mAddressableRefDatas[key].refCount);
        return mAddressableRefDatas[key].resource as T;
    }

    public void ReleaseResource(string key, int decrementRefCount)
    {
        mResourceReleaseDatas.Add(key);
        ReleaseResource(decrementRefCount);
    }

    private void ReleaseResource(int decrementRefCount)
    {
        foreach (var key in mResourceReleaseDatas)
        {
            if (mAddressableRefDatas.TryGetValue(key, out var addressable) == true)
            {
                if (addressable != null && Interlocked.Add(ref addressable.refCount, -decrementRefCount) <= 0)
                    DelayRelease(key, addressable, (60).MillisPerSecond()).Forget();
            }
        }
    }

    private async UniTaskVoid DelayRelease(string key, AddressableRef addressable, int milliseconds)
    {
        if (mReleaseDatas.Contains(key) == true)
            return;

        mReleaseDatas.Add(key);

        int interval = 100;
        int elapsed = 0;

        while (elapsed <= milliseconds)
        {
            await UniTask.Delay(interval);
            elapsed += interval;

            if (addressable.refCount > 0)
            {
                Debug.Log($"Release 취소: {key} ref count가 {addressable.refCount}로 증가");
                break;
            }
        }

        if (addressable.refCount <= 0)
        {
            Addressables.Release(addressable.resource);
            mAddressableRefDatas.Remove(key);
            Debug.Log($"Release asset: {key}");
        }

        mReleaseDatas.Remove(key);
    }
}

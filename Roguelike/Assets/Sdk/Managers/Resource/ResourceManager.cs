using Cysharp.Text;
using Cysharp.Threading.Tasks;
using HYG.Manager.Base;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace HYG.Manager.Resource
{
    public class ResourceManager : SlaveManager
    {
        private AddressablePool mPool = new AddressablePool();

        public async UniTask<Sprite> LoadSpriteAsync(string directory, string name)
        {
            string loadKey = ZString.Concat(Config.SpritePath, "/", directory, "/", name);
            return await LoadAsync<Sprite>(loadKey);
        }

        public async UniTask<string> LoadScript(string directory, string name)
        {
            string loadKey = ZString.Concat(Config.ScriptPath, "/", directory, "/", name);
            return await LoadTextAsync(loadKey);
        }

        public async UniTask<string> LoadTextAsync(string loadKey)
        {
            var asset = await LoadAsync<TextAsset>(loadKey);
            if (asset == null)
                return "";

            return asset.text;
        }

        public AsyncOperationHandle<SceneInstance> LoadScene(Defines.SceneType sceneType, LoadSceneMode sceneMode = LoadSceneMode.Single)
        {
            string loadKey = ZString.Concat(Config.ScenePath, "/", sceneType.ToString(), ".unity");
            var handle = Addressables.LoadSceneAsync(loadKey, sceneMode, true, 100, SceneReleaseMode.ReleaseSceneWhenSceneUnloaded);
            return handle;
        }

        public async UniTask<T> LoadAsync<T>(string key) where T : Object
        {
            return await mPool.LoadAddressable<T>(key);
        }

        public void Release(string key)
        {
            mPool.ReleaseResource(key, 1);
        }
    }
}
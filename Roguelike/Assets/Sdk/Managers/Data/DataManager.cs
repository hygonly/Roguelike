using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HYG.Manager.Data
{
    public abstract class DataManager : HYG.Manager.Base.SlaveManager
    {
        public Defines.DataManagerState State => mState;
        public bool IsLoaded => State == Defines.DataManagerState.Loaded;

        protected Defines.DataManagerState mState;

        public JsonDataManager JsonData => mJsonData;
        protected JsonDataManager mJsonData = new JsonDataManager();

        public async UniTask LoadScript()
        {
            if (mState == Defines.DataManagerState.Loading)
                return;

            mState = Defines.DataManagerState.Loading;

            await JsonData.LoadAll();
            await ConvertListToDictionary();

            mState = Defines.DataManagerState.Loaded;
        }

        protected abstract UniTask ConvertListToDictionary();
    }
}
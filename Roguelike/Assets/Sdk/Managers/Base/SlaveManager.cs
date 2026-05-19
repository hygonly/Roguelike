using UnityEngine;

namespace HYG.Manager.Base
{
    public interface ISalveManager
    {
        IMasterManager GetMaster();

        void RegisterMaster(IMasterManager master);
        void UnregisterMaster();
    }

    public class SlaveManager : ISalveManager
    {
        public IMasterManager GetMaster() { return mMaster; }

        private IMasterManager mMaster;

        protected bool mInit;

        public void RegisterMaster(IMasterManager master)
        {
            mMaster = master;
            Init();
        }

        public void UnregisterMaster()
        {
            if (mMaster == null)
                return;

            mMaster = null;
        }

        protected virtual void Init()
        {
            mInit = true;
        }

        protected virtual void Clear()
        {

        }
    }
}
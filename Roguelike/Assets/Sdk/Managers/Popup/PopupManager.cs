using UniRx;
using UnityEngine;

namespace HYG.Manager.Popup
{
    public class PopupManager : HYG.Manager.Base.SlaveManager
    {
        private UICanvas popupCanvas;

        protected override void Init()
        {
            base.Init();
            GameObject prefab = Resources.Load<GameObject>("PopupCanvas");


            MainThreadDispatcher.UpdateAsObservable().Subscribe(_ =>
            {

            });
        }
        
    }
}
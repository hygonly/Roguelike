using UnityEngine;
using UnityEngine.UI;

namespace HYG.Manager.Popup
{
    public class PopupArg
    {
        public static PopupArg empty = new PopupArg();
    }

    public class PopupBase : MonoBehaviour
    {
        private GraphicRaycaster mGraphicRaycaster;
        private Canvas mCanvas;

        [SerializeField] private bool isFullPopup;

        private void Awake()
        {
            mCanvas = GetComponent<Canvas>();
            mGraphicRaycaster = GetComponent<GraphicRaycaster>();
        }

        public virtual void InitPopupBox(PopupArg _popupData)
        {

        }

        public virtual void PressBackButton()
        {

        }

        public virtual void OnClosePopupBox()
        {

        }
    }
}

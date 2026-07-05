using UnityEngine;

public class UICanvas : MonoBehaviour
{
    public Defines.UICanvasType CanvasType => mCanvasType;

    [SerializeField] private Defines.UICanvasType mCanvasType;

    public static UICanvas MasterCanvas { get; set; }
    public static UICanvas PopupCanvas { get; set; }

    private void Awake()
    {
        if (CanvasType == Defines.UICanvasType.MasterCanvas)
        {
            MasterCanvas = this;
        }
        else if (CanvasType == Defines.UICanvasType.PopupCanvas)
        {
            PopupCanvas = this;
        }
    }

    public void SetSize()
    { 
        //@TODO 해상도 맞춰서 캔버스 크기 맞춰지도록
    }
}

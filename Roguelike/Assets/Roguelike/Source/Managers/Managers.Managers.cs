using UnityEngine;

public class Managers : HYG.Manager.Core.Managers<Managers>
{
    public static ResourceManager Resource => Instance.mResource;
    public static DataManager Data => Instance.mData;
    public static JsonDataManager JsonData => Instance.mData.JsonData;
    public static SceneManagerEx Scene => Instance.mScene;
    public static UserManager User => Instance.mUser;  
    public static TimeManager Time => Instance.mTime;
    public static PoolManager Pool => Instance.mPool;
    public static StringManager String => Instance.mString;
    public static SoundManager Sound => Instance.mSound;
    public static DeviceManager Device => Instance.mDevice;

    private ResourceManager mResource;
    private DataManager mData;
    private SceneManagerEx mScene;
    private UserManager mUser;
    private TimeManager mTime;
    private PoolManager mPool;
    private StringManager mString;
    private SoundManager mSound;
    private DeviceManager mDevice;

    public void InitManager()
    {
        if (mInit == true)
            return;

        mResource = new ResourceManager();
        mData = new DataManager();
        mScene = new SceneManagerEx();
        mUser = new UserManager();
        mTime = new TimeManager();
        mPool = new PoolManager();
        mString = new StringManager();
        mSound = new SoundManager();
        mDevice = new DeviceManager();

        mResource.RegisterMaster(this);
        mData.RegisterMaster(this);
        mScene.RegisterMaster(this);
        mUser.RegisterMaster(this);
        mTime.RegisterMaster(this);
        mPool.RegisterMaster(this);
        mString.RegisterMaster(this);
        mSound.RegisterMaster(this);
        mDevice.RegisterMaster(this);
    }

    public override void Clear()
    {
        mInit = false;
        mResource.UnregisterMaster();
        mData.UnregisterMaster();
        mScene.UnregisterMaster();
        mUser.UnregisterMaster();
        mTime.UnregisterMaster();
        mPool.UnregisterMaster();
        mString.UnregisterMaster();
        mSound.UnregisterMaster();
        mDevice.UnregisterMaster();
        mInstance = null;
        Destroy(gameObject);
    }
}

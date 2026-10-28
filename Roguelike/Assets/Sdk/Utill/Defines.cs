public class Defines
{
    public enum UICanvasType
    {
        MasterCanvas,
        PopupCanvas,
    }

    public enum UserSettingType
    {
        None = 0,
    }

    public enum DataManagerState
    {
        None,
        Loading,
        Loaded,
    }

    public enum SceneType
    {
        StartScene,
        ResourceDownloadScene,
        GameScene
    }

    public enum SystemLanguage
    {
        Korean,
        English,
        Unknown,
    }

    public enum ItemRarity
    {
        None,
        Common,
        Uncommon,
        Rare,
        Epic,
        Unique,
        Legendary,
        Mythic,
    }

    public enum StatType
    {
        None,
        Hp,
        Attack,
        Defense,
    }
}
public partial class Defines
{
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

    public enum OptionType
    {
        Bgm,
        Sfx,
        MoveForward,
        MoveBack,
        MoveRight,
        MoveLeft,
        Action,
        DialogueSpeed,
        BattleSpeed,
    }
}
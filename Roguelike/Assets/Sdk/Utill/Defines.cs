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

    public enum CreatureState
    {
        Idle,
        Move,
        Skill,
        Defense,
        Hit,
        Dead,
    }

    public enum WeaponType
    {
        None,
        Sword,
        Spear,
        Bow,
        Shield,
    }

    public enum InputType
    {
        None,
        Move,
        Jump,
        Attack,
        Defense,
        WeaponSkill1,
        WeaponSkill2,
        Skill1,
        Skill2,
    }

    public enum SkillType
    {
        Active,
        Passive,
    }

    public enum ActiveSkillType
    {
        Instance,
        Casting,
    }

    public enum PassiveSkillType
    {

    }
}
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
        BaseHp,
        BaseAttack,
        BaseDefense,
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

    public enum TransitionState
    {
        None,
        OnEnter,
        OnUpdate,
        OnExit,
        OnFinish,
    }

    public enum SkillType
    {
        Active,
        Passive,
    }

    public enum ActiveSkillType
    {
        Instant,
        Casting,
    }

    public enum SkillEffectType
    {
        None,
        Hit,             //피격
        Heal,            //힐
        DamageReduction, //대미지 감소
    }

    public enum SkillConditionType
    {
        None,
        Hit,
        TakenDamage,
    }

    public enum EffectActionState
    {
        None,
        Enter,
        Update,
        Exit,
        Finish,
    }

    public enum CooldownPolicy
    {
        None,       //없음
        Instant,    //즉발
        Time,       //쿨타임 대기
        Preload,    //에너지 채우기
    }

    public enum EffectHitType
    {

    }
}
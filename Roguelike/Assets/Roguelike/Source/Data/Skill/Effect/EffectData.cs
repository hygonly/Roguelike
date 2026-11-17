using UnityEngine;

public class EffectData
{
    protected int mSkillID;
    protected Defines.SkillType mSkillType;
    
    protected int mEffectID;
    protected Defines.SkillEffectType mEffectType;

    protected string mPreEffectPrefabName;
    protected string mEffectPrefabName;

    protected string mHitEffectPrefabName;
    protected string mBuffEffectPrefabName;

    protected Defines.CooldownPolicy mCooldownPolicy;

}

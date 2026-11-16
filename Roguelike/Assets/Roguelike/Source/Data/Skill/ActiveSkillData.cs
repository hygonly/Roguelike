using UnityEngine;

public class ActiveSkillData : SkillData
{
    public class Builder : Builder<ActiveSkillData>
    {
        public Builder SetSkillData(ActiveSkillInfoScript _script)
        {
            mSkillData.mSkillID = _script.skillID;
            mSkillData.mSkillName = _script.skillName;
            mSkillData.mSkillDesc = _script.skillDesc;
            
            return this;
        }
    }
}

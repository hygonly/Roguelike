using UnityEngine;

public class SkillData
{
    public int SkillID { get { return mSkillID; } }
    public Defines.SkillType SkillType { get { return mSkillType; } }
    public string SkillName { get { return mSkillName; } }
    public string SkillDesc { get { return mSkillDesc; } }
    public int Level { get { return mSkillLevel; } }

    protected int mSkillID;
    protected Defines.SkillType mSkillType;
    protected string mSkillName;
    protected string mSkillDesc;
    protected int mSkillLevel;

    public class Builder<T> where T : SkillData, new()
    {
        protected T mSkillData;

        public Builder()
        {
            mSkillData = new T();
        }

        public T Build()
        {
            return mSkillData;
        }
    }
}
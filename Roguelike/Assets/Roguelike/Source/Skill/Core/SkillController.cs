using System.Collections.Generic;
using UnityEngine;

public abstract class SkillController : MonoBehaviour
{
    private List<SkillHandler> mSkillHandlers = new List<SkillHandler>();

    private bool mInit = false;

    public virtual bool Init(Defines.SkillType _skillType, int _skillID)
    {
        if (mInit == true)
            return false;

        mSkillHandlers = _skillType.CreateSkillHandlers(_skillID);
        mInit = true;
        return true;
    }

    public abstract void Execute();
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
    public abstract void OnFinish();
    
    public virtual void Clear()
    {
        mSkillHandlers.Clear();
        mInit = false;
    }
}

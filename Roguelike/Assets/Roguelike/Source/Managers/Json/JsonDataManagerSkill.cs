using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class JsonDataManager
{
    private Dictionary<int, ActiveSkillInfoScript> mActiveSkillInfoScripts = new Dictionary<int, ActiveSkillInfoScript>();
    private Dictionary<int, List<ActiveSkillEffectInfoScript>> mActiveSkillEffectScripts = new Dictionary<int, List<ActiveSkillEffectInfoScript>>();
    
    private Dictionary<int, List<SkillConditionInfoScript>> mSkillConditionInfoScripts = new Dictionary<int, List<SkillConditionInfoScript>>();

    public UniTask LoadSkill()
    {
        mActiveSkillInfoScripts.Clear();
        mActiveSkillEffectScripts.Clear();
        mSkillConditionInfoScripts.Clear();

        mActiveSkillInfoScripts = GetActiveSkillInfoScriptList.ToDictionary(k => k.skillID, v => v);

        mActiveSkillEffectScripts = GetActiveSkillEffectInfoScriptList.GroupBy(g => g.skillID)
                                                                      .ToDictionary(k => k.Key, v => v.ToList());

        mSkillConditionInfoScripts = GetSkillConditionInfoScriptList.GroupBy(g => g.skillID)
                                                                    .ToDictionary(k => k.Key, v => v.ToList());
        return UniTask.CompletedTask;
    }
}

using System.Collections.Generic;
using UnityEngine;

public static partial class ExtendedHelper
{
    public static List<SkillHandler> CreateSkillHandlers(this Defines.SkillType _skillType, int _skillID)
    {
        var ret = new List<SkillHandler>();
        switch (_skillType)
        {
            case Defines.SkillType.Active:

                break;
        }

        return ret;
    }
}

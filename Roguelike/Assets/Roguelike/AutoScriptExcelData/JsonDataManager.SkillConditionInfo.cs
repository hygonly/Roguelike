/********************************************************/
/*Auto Create File*/
/*Source: ExcelToJson*/
/********************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

[Serializable]
public class SkillConditionInfoScript
{
	public int skillID { get; set; }
	public Defines.SkillConditionType conditionType { get; set; }
	public long conditionSubType { get; set; }
	public long conditionValue { get; set; }

}

public partial class JsonDataManager
{
    private List<SkillConditionInfoScript> GetSkillConditionInfoScriptList { get { return listSkillConditionInfoScript; } }
    private List<SkillConditionInfoScript> listSkillConditionInfoScript;

    [Serializable]
    public class SkillConditionInfoScriptAll
    {
        public List<SkillConditionInfoScript> result;
    }

    public async UniTask LoadSkillConditionInfoScript()
    {
        var resultScript = new List<SkillConditionInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("skill", "skillConditionInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load skillConditionInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<SkillConditionInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: skillConditionInfo.json Script\n {e.Message}");
        }
        
        listSkillConditionInfoScript = resultScript;
        Complete();
    }

    public void ClearSkillConditionInfoScript()
    {
        listSkillConditionInfoScript?.Clear();
    }
}
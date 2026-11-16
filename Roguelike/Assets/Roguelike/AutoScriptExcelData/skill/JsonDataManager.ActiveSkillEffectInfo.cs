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
public class ActiveSkillEffectInfoScript
{
	public int skillID { get; set; }
	public Defines.SkillEffectType effectType { get; set; }
	public long skillValueFrom10000 { get; set; }

}

public partial class JsonDataManager
{
    private List<ActiveSkillEffectInfoScript> GetActiveSkillEffectInfoScriptList { get { return listActiveSkillEffectInfoScript; } }
    private List<ActiveSkillEffectInfoScript> listActiveSkillEffectInfoScript;

    [Serializable]
    public class ActiveSkillEffectInfoScriptAll
    {
        public List<ActiveSkillEffectInfoScript> result;
    }

    public async UniTask LoadActiveSkillEffectInfoScript()
    {
        var resultScript = new List<ActiveSkillEffectInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("skill", "activeSkillEffectInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load activeSkillEffectInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<ActiveSkillEffectInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: activeSkillEffectInfo.json Script\n {e.Message}");
        }
        
        listActiveSkillEffectInfoScript = resultScript;
        Complete();
    }

    public void ClearActiveSkillEffectInfoScript()
    {
        listActiveSkillEffectInfoScript?.Clear();
    }
}
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
public class ActiveSkillInfoScript
{
	public int skillID { get; set; }
	public Defines.ActiveSkillType skillType { get; set; }
	public string skillName { get; set; }
	public string skillDesc { get; set; }
	public string prefab { get; set; }

}

public partial class JsonDataManager
{
    private List<ActiveSkillInfoScript> GetActiveSkillInfoScriptList { get { return listActiveSkillInfoScript; } }
    private List<ActiveSkillInfoScript> listActiveSkillInfoScript;

    [Serializable]
    public class ActiveSkillInfoScriptAll
    {
        public List<ActiveSkillInfoScript> result;
    }

    public async UniTask LoadActiveSkillInfoScript()
    {
        var resultScript = new List<ActiveSkillInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("skill", "activeSkillInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load activeSkillInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<ActiveSkillInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: activeSkillInfo.json Script\n {e.Message}");
        }
        
        listActiveSkillInfoScript = resultScript;
        Complete();
    }

    public void ClearActiveSkillInfoScript()
    {
        listActiveSkillInfoScript?.Clear();
    }
}
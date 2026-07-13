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
public class WeaponSkillInfoScript
{
	public Int64 weaponSkillID { get; set; }
	public Int64 skillNameStr { get; set; }
	public Int64 skillDescStr { get; set; }

}

public partial class JsonDataManager
{
    private List<WeaponSkillInfoScript> GetWeaponSkillInfoScriptList { get { return listWeaponSkillInfoScript; } }
    private List<WeaponSkillInfoScript> listWeaponSkillInfoScript;

    [Serializable]
    public class WeaponSkillInfoScriptAll
    {
        public List<WeaponSkillInfoScript> result;
    }

    public async UniTask LoadWeaponSkillInfoScript()
    {
        var resultScript = new List<WeaponSkillInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("equipment", "weaponSkillInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load weaponSkillInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<WeaponSkillInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: weaponSkillInfo.json Script\n {e.Message}");
        }
        
        listWeaponSkillInfoScript = resultScript;
        Complete();
    }

    public void ClearWeaponSkillInfoScript()
    {
        listWeaponSkillInfoScript?.Clear();
    }
}
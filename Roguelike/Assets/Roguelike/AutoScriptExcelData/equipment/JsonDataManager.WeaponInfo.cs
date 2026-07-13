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
public class WeaponInfoScript
{
	public Int64 weaponID { get; set; }
	public Defines.ItemRarity rarityType { get; set; }
	public Int64 nameStrID { get; set; }
	public Int64 descStrID { get; set; }

}

public partial class JsonDataManager
{
    private List<WeaponInfoScript> GetWeaponInfoScriptList { get { return listWeaponInfoScript; } }
    private List<WeaponInfoScript> listWeaponInfoScript;

    [Serializable]
    public class WeaponInfoScriptAll
    {
        public List<WeaponInfoScript> result;
    }

    public async UniTask LoadWeaponInfoScript()
    {
        var resultScript = new List<WeaponInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("equipment", "weaponInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load weaponInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<WeaponInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: weaponInfo.json Script\n {e.Message}");
        }
        
        listWeaponInfoScript = resultScript;
        Complete();
    }

    public void ClearWeaponInfoScript()
    {
        listWeaponInfoScript?.Clear();
    }
}
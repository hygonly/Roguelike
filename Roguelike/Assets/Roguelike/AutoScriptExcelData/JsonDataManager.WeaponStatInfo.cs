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
public class WeaponStatInfoScript
{
	public Int64 weaponID { get; set; }
	public Defines.StatType statType { get; set; }
	public Int64 statValueFrom10000 { get; set; }

}

public partial class JsonDataManager
{
    private List<WeaponStatInfoScript> GetWeaponStatInfoScriptList { get { return listWeaponStatInfoScript; } }
    private List<WeaponStatInfoScript> listWeaponStatInfoScript;

    [Serializable]
    public class WeaponStatInfoScriptAll
    {
        public List<WeaponStatInfoScript> result;
    }

    public async UniTask LoadWeaponStatInfoScript()
    {
        var resultScript = new List<WeaponStatInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("equipment", "weaponStatInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load weaponStatInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<WeaponStatInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: weaponStatInfo.json Script\n {e.Message}");
        }
        
        listWeaponStatInfoScript = resultScript;
        Complete();
    }

    public void ClearWeaponStatInfoScript()
    {
        listWeaponStatInfoScript?.Clear();
    }
}
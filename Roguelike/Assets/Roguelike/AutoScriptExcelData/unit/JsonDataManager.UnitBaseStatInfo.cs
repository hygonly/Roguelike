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
public class UnitBaseStatInfoScript
{
	public Defines.StatType statType { get; set; }
	public Int64 statValue10000 { get; set; }

}

public partial class JsonDataManager
{
    private List<UnitBaseStatInfoScript> GetUnitBaseStatInfoScriptList { get { return listUnitBaseStatInfoScript; } }
    private List<UnitBaseStatInfoScript> listUnitBaseStatInfoScript;

    [Serializable]
    public class UnitBaseStatInfoScriptAll
    {
        public List<UnitBaseStatInfoScript> result;
    }

    public async UniTask LoadUnitBaseStatInfoScript()
    {
        var resultScript = new List<UnitBaseStatInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("unit", "unitBaseStatInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load unitBaseStatInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<UnitBaseStatInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: unitBaseStatInfo.json Script\n {e.Message}");
        }
        
        listUnitBaseStatInfoScript = resultScript;
        Complete();
    }

    public void ClearUnitBaseStatInfoScript()
    {
        listUnitBaseStatInfoScript?.Clear();
    }
}
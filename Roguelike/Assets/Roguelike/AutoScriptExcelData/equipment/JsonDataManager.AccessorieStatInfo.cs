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
public class AccessorieStatInfoScript
{
	public Int64 accessorieID { get; set; }
	public Defines.StatType statType { get; set; }
	public Int64 statValueFrom10000 { get; set; }

}

public partial class JsonDataManager
{
    private List<AccessorieStatInfoScript> GetAccessorieStatInfoScriptList { get { return listAccessorieStatInfoScript; } }
    private List<AccessorieStatInfoScript> listAccessorieStatInfoScript;

    [Serializable]
    public class AccessorieStatInfoScriptAll
    {
        public List<AccessorieStatInfoScript> result;
    }

    public async UniTask LoadAccessorieStatInfoScript()
    {
        var resultScript = new List<AccessorieStatInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("equipment", "accessorieStatInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load accessorieStatInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<AccessorieStatInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: accessorieStatInfo.json Script\n {e.Message}");
        }
        
        listAccessorieStatInfoScript = resultScript;
        Complete();
    }

    public void ClearAccessorieStatInfoScript()
    {
        listAccessorieStatInfoScript?.Clear();
    }
}
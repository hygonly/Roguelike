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
public class AccessorieInfoScript
{
	public Int64 accessorieID { get; set; }
	public Defines.ItemRarity rarityType { get; set; }
	public Int64 nameStrID { get; set; }
	public Int64 descStrID { get; set; }

}

public partial class JsonDataManager
{
    private List<AccessorieInfoScript> GetAccessorieInfoScriptList { get { return listAccessorieInfoScript; } }
    private List<AccessorieInfoScript> listAccessorieInfoScript;

    [Serializable]
    public class AccessorieInfoScriptAll
    {
        public List<AccessorieInfoScript> result;
    }

    public async UniTask LoadAccessorieInfoScript()
    {
        var resultScript = new List<AccessorieInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("equipment", "accessorieInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load accessorieInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<AccessorieInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: accessorieInfo.json Script\n {e.Message}");
        }
        
        listAccessorieInfoScript = resultScript;
        Complete();
    }

    public void ClearAccessorieInfoScript()
    {
        listAccessorieInfoScript?.Clear();
    }
}
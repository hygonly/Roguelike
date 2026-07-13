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
public class MonsterInfoScript
{
	public Int64 monsterID { get; set; }

}

public partial class JsonDataManager
{
    private List<MonsterInfoScript> GetMonsterInfoScriptList { get { return listMonsterInfoScript; } }
    private List<MonsterInfoScript> listMonsterInfoScript;

    [Serializable]
    public class MonsterInfoScriptAll
    {
        public List<MonsterInfoScript> result;
    }

    public async UniTask LoadMonsterInfoScript()
    {
        var resultScript = new List<MonsterInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("monster", "monsterInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load monsterInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<MonsterInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: monsterInfo.json Script\n {e.Message}");
        }
        
        listMonsterInfoScript = resultScript;
        Complete();
    }

    public void ClearMonsterInfoScript()
    {
        listMonsterInfoScript?.Clear();
    }
}
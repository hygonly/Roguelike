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
public class UserSettingScript
{
	public Defines.UserSettingType userSettingType { get; set; }
	public Int64 value { get; set; }

}

public partial class JsonDataManager
{
    private List<UserSettingScript> GetUserSettingScriptList { get { return listUserSettingScript; } }
    private List<UserSettingScript> listUserSettingScript;

    [Serializable]
    public class UserSettingScriptAll
    {
        public List<UserSettingScript> result;
    }

    public async UniTask LoadUserSettingScript()
    {
        var resultScript = new List<UserSettingScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("user", "userSetting.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load userSetting.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<UserSettingScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: userSetting.json Script\n {e.Message}");
        }
        
        listUserSettingScript = resultScript;
        Complete();
    }

    public void ClearUserSettingScript()
    {
        listUserSettingScript?.Clear();
    }
}
using ExcelToJson.Manager;
using ExcelToJson.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToJson
{
    public partial class Client_JsonDataManagerFormatter
    {
        //{0}: Class name
        //{1}: Parent file name
        //{2}: File name
        //{3}: Fields
        public string ClientJsonDataManagerFormat =
@"/********************************************************/
/*Auto Create File*/
/*Source: ExcelToJson*/
/********************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

[Serializable]
public class {0}Script
{{
{3}
}}

public partial class JsonDataManager
{{
    private List<{0}Script> Get{0}ScriptList {{ get {{ return list{0}Script; }} }}
    private List<{0}Script> list{0}Script;

    [Serializable]
    public class {0}ScriptAll
    {{
        public List<{0}Script> result;
    }}

    public async UniTask Load{0}Script()
    {{
        var resultScript = new List<{0}Script>();

        try
        {{
            var load = await Managers.Resource.LoadScript(""{1}"", ""{2}"");
            if (string.IsNullOrEmpty(load) == true)
            {{
                Debug.LogError(""Failed load {2} Script"");
                return;
            }}

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<{0}ScriptAll>(""{{ \""result\"" : "" + load + ""}}"", settings);
            resultScript = json.result;
        }}
        catch (Exception e)
        {{
            Debug.LogError($""Load Failed: {2} Script\n {{e.Message}}"");
        }}
        
        list{0}Script = resultScript;
        Complete();
    }}

    public void Clear{0}Script()
    {{
        list{0}Script?.Clear();
    }}
}}";

        //{0}: Clear scripts
        //{1}: Load scripts
        public string ClientJsonDataManagerLoaderFormat =
@"/********************************************************/
/*Auto Create File*/
/*Source: ExcelToJson*/
/********************************************************/

using Cysharp.Threading.Tasks;

public partial class JsonDataManager
{{
    public int LoadCount {{ get {{ return _loadCount; }} }}
    public int MaxCount {{ get {{ return _maxCount;  }} }}

    private int _loadCount;
    private int _maxCount;

    public void Complete()
    {{
        _loadCount++;
    }}

    public float GetLoadProgress() {{ return (float)_loadCount / _maxCount; }}

    public async UniTask LoadAll()
    {{
        _loadCount = 0;
{0}
        await UniTask.WhenAll(
{1}
        );
    }}
}}";

        public class Builder
        {
            JsonFormatter _jsonFormat;
            Client_JsonDataManagerFormatter _jsonDataManagerFormat;

            public Builder()
            {
                _jsonFormat = new JsonFormatter();
                _jsonDataManagerFormat = new Client_JsonDataManagerFormatter();
            }

            public void CreateJson(JsonInfo fieldInfo, string directory, string file)
            {
                string directoryPath = string.Concat(Managers.InI.GetValue(Defines.InIKeyType.ClientJsonPath), "/", directory);
                if (Directory.Exists(directoryPath) == false)
                    Directory.CreateDirectory(directoryPath);

                if (file.Contains(".json") == false)
                    file += ".json";

                string fullPath = string.Concat(directoryPath, "/", file);
                string result = _jsonFormat.GetJson(fieldInfo);
                File.WriteAllText(fullPath, result);
            }
            
            public string CreateJsonDataManager(List<SourceFieldInfo> fieldInfos, string directory, string file)
            {
                string field = "";
                foreach (SourceFieldInfo fieldInfo in fieldInfos)
                    field += "\t" + string.Format(_jsonFormat.FieldFormat, fieldInfo.type, fieldInfo.name);

                string directoryPath = string.Concat(Managers.InI.GetValue(Defines.InIKeyType.ClientSourcePath), "/", directory);
                string fullPath = string.Concat(directoryPath, "/", StringHelper.GetScriptName(file));
                if (Directory.Exists(directoryPath) == false)
                    Directory.CreateDirectory(directoryPath);

                string className = StringHelper.GetClassName(file);
                string result = string.Format(_jsonDataManagerFormat.ClientJsonDataManagerFormat, className, directory, file + ".json", field);
                File.WriteAllText(fullPath, result);
                return className;
            }

            public void CreateJsonDataManagerLoader(List<string> classNames)
            {
                string fileName = "JsonDataManager.Loader.cs";
                string clearSource = "";
                foreach (string className in classNames)
                    clearSource += string.Format("\t\t" + _jsonFormat.ClearFormat, className);

                string loadSource = "";
                for (int i = 0; i < classNames.Count - 1; i++)
                    loadSource += string.Format("\t\t\t" + _jsonFormat.LoadFormat, classNames[i]) + ",\n";

                loadSource += string.Format("\t\t\t" + _jsonFormat.LoadFormat, classNames[classNames.Count - 1]);
                    

                string result = string.Format(_jsonDataManagerFormat.ClientJsonDataManagerLoaderFormat, clearSource, loadSource);
                string path = string.Concat(Managers.InI.GetValue(Defines.InIKeyType.ClientSourcePath), "/", fileName);
                File.WriteAllText(path, result);
            }
        }
    }
}

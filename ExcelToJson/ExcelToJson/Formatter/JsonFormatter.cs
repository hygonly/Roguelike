using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToJson
{
    public partial class JsonFormatter
    {
        public const string JsonFieldFormat = "\t\t\"{0}\": \"{1}\",\n";
        public string FieldFormat = "public {0} {1} {{ get; set; }}\n";
        public string LoadFormat = "Load{0}Script()";
        public string ClearFormat = "Clear{0}Script();\n";

        public string GetJson(JsonInfo fieldInfo)
        {
            var obj = fieldInfo.infos.Select(_1 => _1.Value.ToDictionary(f => f.name, f => f.value)).ToList();
            string result = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return result;
        }
    }
}

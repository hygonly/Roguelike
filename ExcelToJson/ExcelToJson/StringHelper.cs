using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToJson
{
    public static class StringHelper
    {
        public static string GetClassName(string info)
        {
            int index = info.IndexOf("_");
            string className = info;
            if (index > 0)
                className = info.Substring(index + 1);

            string upper = className[0].ToString().ToUpper();
            string ret = upper + className.Substring(1);
            return ret;
        }

        public static string GetDirectoryName(string info)
        {
            int index = info.IndexOf("_");
            string directoryName = info.Substring(0, index);
            return directoryName;
        }

        public static string GetFileName(string info)
        {
            int index = info.IndexOf("_");
            string fileName = info.Substring(index + 1);
            return fileName;
        }

        public static string GetScriptName(string fileName)
        {
            string result = string.Concat("JsonDataManager", "." ,fileName[0].ToString().ToUpper(), fileName.Substring(1), ".cs");

            return result;
        }

        public static string GetVariableName(string info)
        {
            int index = info.LastIndexOf(".");
            string variable = info.Substring(index + 1);
            return variable;
        }

        public static string GetFieldType(string info)
        {
            int index = info.LastIndexOf(".");
            if (index <= 0)
                return "int";

            string fieldType = info.Substring(0, index);
            return fieldType;
        }
    }
}

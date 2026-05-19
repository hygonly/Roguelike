using ExcelDataReader;
using ExcelToJson.Manager;
using ExcelToJson.Utils;
using System.Data;
using System.Text;

namespace ExcelToJson
{
    public record struct SourceFieldInfo(string name, string type);
    public record struct JsonFieldInfo(string name, string value);
    public record struct JsonInfo(string directory, string fileName, Dictionary<int, List<JsonFieldInfo>> infos);

    public class ConvertManager
    {
        public List<FileInfo> GetExcelFiles()
        {
            string excelPath = Managers.InI.GetValue(Defines.InIKeyType.ExcelPath);
            if (string.IsNullOrEmpty(excelPath) == true)
                return new List<FileInfo>();

            DirectoryInfo directory = new DirectoryInfo(excelPath);
            return directory.GetFiles().Where(_ => _.Name.StartsWith("~$") == false).ToList();
        }

        public bool BuildExcelDataToClient()
        {
            try
            {
                Client_JsonDataManagerFormatter.Builder builder = new Client_JsonDataManagerFormatter.Builder();
                var classNames = new List<string>();
                foreach (FileInfo fileInfo in GetExcelFiles())
                {
                    if (fileInfo.Name.StartsWith("~$"))
                        continue;

                    FileStream stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var config = new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = true
                            }
                        };

                        var tables = reader.AsDataSet(config).Tables;
                        JsonInfo json = new JsonInfo();

                        //public string name 같은 소스 변수
                        for (int tableIndex = 0; tableIndex < tables.Count; tableIndex++)
                        {
                            //엑셀 데이터를 json 형식으로 변환
                            var table = tables[tableIndex];
                            var rows = tables[tableIndex].Rows;
                            var sourceFieldInfos = ConvertSourceFieldInfo(table.Columns);

                            string tableName = table.TableName;
                            string directoryName = StringHelper.GetDirectoryName(tableName);
                            string fileName = StringHelper.GetFileName(tableName);

                            json.infos = new();
                            json.directory = directoryName;
                            json.fileName = fileName;

                            for (int i = 0; i < rows.Count; i++)
                            {
                                var jsonFieldInfos = ConvertJsonFieldInfo(rows[i], sourceFieldInfos);
                                json.infos.Add(i, jsonFieldInfos);
                            }

                            classNames.Add(StringHelper.GetClassName(tableName));
                            builder.CreateJsonDataManager(sourceFieldInfos, directoryName, fileName);
                            builder.CreateJson(json, directoryName, fileName);
                        }

                        reader.Dispose();
                        reader.Close();
                    }
                }

                builder.CreateJsonDataManagerLoader(classNames);
            }
            catch (Exception e)
            {

                return false;
            }

            return true;
        }

        private List<SourceFieldInfo> ConvertSourceFieldInfo(DataColumnCollection collection)
        {
            List<SourceFieldInfo> result = new List<SourceFieldInfo>();
            for (int i = 0; i < collection.Count; i++)
            {
                SourceFieldInfo info = new SourceFieldInfo();
                string field = collection[i].ColumnName;
                if (field.Contains("~") == true)
                    continue;


                info.type = StringHelper.GetFieldType(field);
                info.name = StringHelper.GetVariableName(field);
                result.Add(info);
            }

            return result;
        }

        private List<JsonFieldInfo> ConvertJsonFieldInfo(DataRow collection, List<SourceFieldInfo> fieldInfos)
        {
            List<JsonFieldInfo> result = new List<JsonFieldInfo>();
            for (int i = 0; i < fieldInfos.Count; i++)
            {
                JsonFieldInfo jsonFieldInfo = new JsonFieldInfo();
                jsonFieldInfo.name = fieldInfos[i].name;
                jsonFieldInfo.value = collection.ItemArray[i].ToString();
                result.Add(jsonFieldInfo);
            }

            return result;
        }

        public void Clear()
        {
            string clientJsonPath = Managers.InI.GetValue(Defines.InIKeyType.ClientJsonPath);
            if (string.IsNullOrEmpty(clientJsonPath) == false)
            {
                if (Directory.Exists(clientJsonPath) == true)
                    Directory.Delete(clientJsonPath, true);
            }

            string clientSourcePath = Managers.InI.GetValue(Defines.InIKeyType.ClientSourcePath);
            if (string.IsNullOrEmpty(clientSourcePath) == false)
            {
                if (Directory.Exists(clientSourcePath) == true)
                    Directory.Delete(clientSourcePath, true);
            }

            string servertJsonPath = Managers.InI.GetValue(Defines.InIKeyType.ServerJsonPath);
            if (string.IsNullOrEmpty(servertJsonPath) == false)
            {
                if (Directory.Exists(clientSourcePath) == true)
                    Directory.Delete(clientSourcePath, true);
            }

            string serverSourcePath = Managers.InI.GetValue(Defines.InIKeyType.ServerSourcePath);
            if (string.IsNullOrEmpty(serverSourcePath) == false)
            {
                if (Directory.Exists(serverSourcePath) == true)
                    Directory.Delete(serverSourcePath, true);
            }
        }
    }
}
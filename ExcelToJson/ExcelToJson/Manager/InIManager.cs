using ExcelToJson.Utils;
using System.Runtime.InteropServices;
using System.Text;

namespace ExcelToJson.Manager
{
    public class InIManager
    {
        public void Init()
        {
            if (File.Exists(GetInIPath) == false)
            {
                FileStream buffer = File.Create(GetInIPath);
                buffer.Close();
            }
        }

        public string GetInIPath
        {
            get
            {
                string path = Application.StartupPath + @"\config.ini";
                return path;
            }
        }

        private const string SECTION = "SYSTEM";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public void SetValue(Defines.InIKeyType key, string value)
        {
            WritePrivateProfileString(SECTION, key.ToString(), value, GetInIPath);
        }

        public string GetValue(Defines.InIKeyType key)
        {
            StringBuilder builder = new StringBuilder(255);
            int size = GetPrivateProfileString(SECTION, key.ToString(), "", builder, 255, GetInIPath);
            if (builder != null)
                return builder.ToString();

            return "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToJson.Utils
{
    public class Defines
    {
        public enum InIKeyType
        {
            None = 0,
            ExcelPath,
            ClientJsonPath,
            ClientSourcePath,
            ServerJsonPath,
            ServerSourcePath,
        }
    }
}

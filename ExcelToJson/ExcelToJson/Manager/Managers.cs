using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToJson.Manager
{
    public class Managers
    {
        public static Managers Instance 
        { 
            get 
            { 
                if (_instance == null)
                {
                    _instance = new Managers();
                    Init();
                }

                return _instance; 
            } 
        }

        private static Managers _instance;

        public static InIManager InI => Instance._ini;
        public static ConvertManager Convert => Instance._convert;

        private InIManager _ini;
        private ConvertManager _convert;

        private static void Init()
        {
            _instance._ini = new InIManager();
            _instance._ini.Init();

            _instance._convert = new ConvertManager();
        }
    }
}

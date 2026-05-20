using System.Collections.Generic;
using UnityEngine;

namespace HYG.Manager.String
{
    public class StringManager : HYG.Manager.Base.SlaveManager
    {
        protected Dictionary<int, string> mStringDictKr = new Dictionary<int, string>();
        protected Dictionary<int, string> mStringDictEng = new Dictionary<int, string>();

        protected override void Init()
        {
            
        }

        public string GetString(int stringID)
        {
            return mStringDictKr.GetValueOrDefault(stringID);
        }
    }
}


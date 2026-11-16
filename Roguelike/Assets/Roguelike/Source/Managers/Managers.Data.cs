using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

public class DataManager : HYG.Manager.Data.DataManager
{
    protected override UniTask ConvertListToDictionary()
    {
        UniTask.WhenAll(
            JsonData.LoadSkill()
            );

        return UniTask.CompletedTask;
    }
}

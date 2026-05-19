using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

public class DataManager : HYG.Manager.Data.DataManager
{
    protected override async UniTask ConvertListToDictionary()
    {
        await UniTask.CompletedTask;
    }
}

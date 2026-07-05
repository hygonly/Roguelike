using UnityEngine;

public class StatCore
{
    protected StatRuntimeData mRuntimeData = new StatRuntimeData();
    protected StatStorageData mStorageData = new StatStorageData();

    public double CacluateStat(Defines.StatType _statType)
    {
        var baseStat = mStorageData.GetBaseStat(_statType);
        var buffStat = mStorageData.GetBuffStat(_statType);
        var debuffStat = mStorageData.GetDebuffStat(_statType);

        var result = baseStat + buffStat + debuffStat;
        mRuntimeData.SetTotalStat(_statType, result);
        return result;
    }
}

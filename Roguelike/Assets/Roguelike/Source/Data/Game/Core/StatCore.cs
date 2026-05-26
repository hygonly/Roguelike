using UnityEngine;

public class StatCore
{
    protected StatStorageData mStorageData = new StatStorageData();
    protected StatRuntimeData mRuntimeData = new StatRuntimeData();

    public double GetCalcStats(Defines.StatType statType)
    {
        double baseStat = mStorageData.GetBaseStat(statType);
        double buffStat = mStorageData.GetBuffStat(statType);
        double debuffStat = mStorageData.GetDebuffStat(statType);

        double calcStatValue = baseStat + buffStat - debuffStat;
        mRuntimeData.SetTotalStat(statType, calcStatValue);
        return calcStatValue;
    }


}

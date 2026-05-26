using UnityEngine;

public class StatStorageData
{
    private StatData mBaseStatData = new StatData();
    private StatData mBuffData = new StatData();
    private StatData mDebuffData = new StatData();

    public double SetBaseStat(Defines.StatType statType, double value) => mBaseStatData.SetStat(statType, value);
    public double IncreaseBaseStat(Defines.StatType statType, double value) => mBaseStatData.IncreaseStat(statType, value);
    public double DecreaseBaseStat(Defines.StatType statType, double value) => mBaseStatData.DecreaseStat(statType, value);

    public double SetBuffStat(Defines.StatType statType, double value) => mBuffData.SetStat(statType, value);
    public double IncreaseBuffStat(Defines.StatType statType, double value) => mBuffData.IncreaseStat(statType, value);
    public double DecreaseBuffStat(Defines.StatType statType, double value) => mBuffData.DecreaseStat(statType, value);

    public double SetDebuffStat(Defines.StatType statType, double value) => mDebuffData.SetStat(statType, value);
    public double IncreaseDebuffStat(Defines.StatType statType, double value) => mDebuffData.IncreaseStat(statType, value);
    public double DecreaseDebuffStat(Defines.StatType statType, double value) => mDebuffData.DecreaseStat(statType, value);

    public double GetBaseStat(Defines.StatType statType) => mBaseStatData.GetStat(statType);
    public double GetBuffStat(Defines.StatType statType) => mBuffData.GetStat(statType);
    public double GetDebuffStat(Defines.StatType statType) => mDebuffData.GetStat(statType);
}

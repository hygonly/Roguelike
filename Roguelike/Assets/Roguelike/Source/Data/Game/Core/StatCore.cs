using UnityEngine;

public class StatCore
{
    protected StatData mBaseStatData = new StatData();
    protected StatData mBuffData = new StatData();
    protected StatData mDebuffData = new StatData();

    public double SetBuffStat(Defines.StatType statType, double value) => mBuffData.SetStat(statType, value);

    
}

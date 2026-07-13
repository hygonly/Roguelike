using System.Collections.Generic;
using UnityEngine;

public class StatData
{
    protected Dictionary<Defines.StatType, double> mStats = new Dictionary<Defines.StatType, double>();
    
    public double GetStats(Defines.StatType _statType)
    {
        if (mStats.TryGetValue(_statType, out var ret) == false)
            return 0d;

        return ret;
    }

    public double SetStat(Defines.StatType _statType, double _value)
    {
        mStats[_statType] = _value;
        return mStats[_statType];
    }

    public double IncreamentStat(Defines.StatType _statType, double _value)
    {
        if (mStats.TryGetValue(_statType, out var currentValue) == false)
            return 0d;

        var value = currentValue + _value;
        mStats[_statType] = value;
        return value;
    }

    public double DecreamentStat(Defines.StatType _statType, double _value)
    {
        if (mStats.TryGetValue(_statType, out var currentValue) == false)
            return 0d;

        var value = currentValue - _value;
        mStats[_statType] = value;
        return value;
    }
}
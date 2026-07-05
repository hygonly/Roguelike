using System.Collections.Generic;
using UnityEngine;

public class StatData
{
    protected Dictionary<Defines.StatType, double> mStats = new Dictionary<Defines.StatType, double>();

    public double IncreamentStat(Defines.StatType _statType, double _value)
    {
        if (mStats.TryGetValue(_statType, out var currentValue) == false)
            return 0d;

        var newValue = currentValue + _value;
        mStats[_statType] = newValue;
        return newValue;
    }

    public double DecreamentStat(Defines.StatType _statType, double _value)
    {
        if (mStats.TryGetValue(_statType, out var result) == false)
            return 0d;

        var newValue = result - _value;
        mStats[_statType] = newValue;
        return newValue;
    }

    public double SetStat(Defines.StatType _statType, double _value)
    {
        mStats[_statType] = _value;
        return _value;
    }

    public double SetStat1000(Defines.StatType _statType, long _value)
    {
        mStats[_statType] = _value.From1000();
        return _value;
    }

    public double GetStat(Defines.StatType _statType)
    {
        if (mStats.TryGetValue(_statType, out var ret) == false)
            return 0d;

        return ret;
    }
}

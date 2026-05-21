using System;
using System.Collections.Generic;
using UnityEngine;

public class StatData
{
    public Dictionary<Defines.StatType, double> StatDatas { get; private set; } = new Dictionary<Defines.StatType, double>();

    public double IncreaseStat(Defines.StatType statType, double statValue)
    {
        if (StatDatas.TryGetValue(statType, out var currentValue) == false)
            return 0d;

        double value = currentValue = statValue;
        StatDatas[statType] = value;
        return value;
    }

    public double DecreaseStat(Defines.StatType statType, double statValue)
    {
        if (StatDatas.TryGetValue(statType, out var currentValue) == false)
            return 0f;

        double value = currentValue - statValue;
        StatDatas[statType] = value;
        return value;
    }

    public double SetStat(Defines.StatType statType, double statValue)
    {
        StatDatas[statType] = statValue;
        return statValue;
    }

    public double SetStat1000(Defines.StatType statType, long statValue)
    {
        double value = statValue * 0.001d;
        StatDatas[statType] = value;
        return value;
    }

    public double GetStat(Defines.StatType statType)
    {
        if (StatDatas.TryGetValue(statType, out var ret) == false)
            return 0d;

        return ret;
    }
}

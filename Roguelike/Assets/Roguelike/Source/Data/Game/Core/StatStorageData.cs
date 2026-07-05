using System.Collections.Generic;
using UnityEngine;

public class StatStorageData
{
    private StatData mBaseStat = new StatData();
    private StatData mBuffStat = new StatData();
    private StatData mDebuffStat = new StatData();
    
    public double IncreamentBaseStat(Defines.StatType _statType, double _value) => mBaseStat.IncreamentStat(_statType, _value);
    public double DecreamentBaseStat(Defines.StatType _statType, double _value) => mBaseStat.DecreamentStat(_statType, _value);
    public double SetBaseStat(Defines.StatType _statType, double _value) => mBaseStat.SetStat(_statType, _value);
    public double SetBaseStat1000(Defines.StatType _statType, long _value) => mBaseStat.SetStat1000(_statType, _value);
    public double GetBaseStat(Defines.StatType _statType) => mBaseStat.GetStat(_statType);

    public double IncreamentBuffStat(Defines.StatType _statType, double _value) => mBuffStat.IncreamentStat(_statType, _value);
    public double DecreamentBuffStat(Defines.StatType _statType, double _value) => mBuffStat.DecreamentStat(_statType, _value);
    public double SetBuffStat(Defines.StatType _statType, double _value) => mBuffStat.SetStat(_statType, _value);
    public double SetBuffStat1000(Defines.StatType _statType, long _value) => mBuffStat.SetStat1000(_statType, _value);
    public double GetBuffStat(Defines.StatType _statType) => mBuffStat.GetStat(_statType);

    public double IncreamentDebuffStat(Defines.StatType _statType, double _value) => mDebuffStat.IncreamentStat(_statType, _value);
    public double DecreamentDebuffStat(Defines.StatType _statType, double _value) => mDebuffStat.DecreamentStat(_statType, _value);
    public double SetDeBuffStat(Defines.StatType _statType, double _value) => mDebuffStat.SetStat(_statType, _value);
    public double SetDeBuffStat1000(Defines.StatType _statType, long _value) => mDebuffStat.SetStat1000(_statType, _value);
    public double GetDebuffStat(Defines.StatType _statType) => mDebuffStat.GetStat(_statType);

}
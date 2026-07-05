using System.Collections.Generic;
using UnityEngine;

public class StatRuntimeData
{
    private Dictionary<Defines.StatType, double> mTotalStats = new Dictionary<Defines.StatType, double>();

    private int mMaxHp;
    private int mHp;
    private double mFinalAttack;
    private double mFinalDefense;

    public int MaxHp => mMaxHp;
    public int Hp => mHp;
    public double FinalAttack => mFinalAttack;
    public double FinalDefense => mFinalDefense;

    public double GetTotalStat(Defines.StatType _statType)
    {
        if (mTotalStats.TryGetValue(_statType, out var value) == false)
            return 0d;

        return value;
    }

    public double SetTotalStat(Defines.StatType _statType, double _value)
    {
        mTotalStats[_statType] = _value;
        return _value;
    }

    public void SetHp(int _hp)
    {
        mHp = _hp;
    }

    public void SetMaxHp(int _maxHp)
    {
        mMaxHp = _maxHp;
        mHp = _maxHp;
    }

    public void ResetHp(int _hp)
    {
        mMaxHp = _hp;
        mHp = _hp;
    }

    public void SetFinalAttack(double _finalAttack) => mFinalAttack = _finalAttack;
    public void SetFinalDefense(double _finalDefense) => mFinalDefense = _finalDefense;
    public void SetRuntimeMaxHp(int _maxHp) => mMaxHp = _maxHp;
}

using System.Collections.Generic;
using UnityEngine;

public class StatRuntimeData
{
    private Dictionary<Defines.StatType, double> mTotalStatDatas = new Dictionary<Defines.StatType, double>();

    private int mHp;
    private int mMaxHp;
    private double mFinalAttack;
    private double mFinalDefense;
    private double mJumpPower;
    private double mMoveSpeed;

    public double FinalAttack => mFinalAttack;
    public double FinalDefense => mFinalDefense;
    public int MaxHp => mMaxHp;
    public int Hp => mHp;
    public double JumpPower => mJumpPower;
    public double MoveSpeed => mMoveSpeed;

    public double GetTotalStat(Defines.StatType statType)
    {
        if (mTotalStatDatas.TryGetValue(statType, out var value) == false)
        {
            mTotalStatDatas.Add(statType, 0d);
            return 0d;
        }

        return value;
    }

    public void SetTotalStat(Defines.StatType statType, double value)
    {
        mTotalStatDatas[statType] = value;
    }

    public void SetHp(int hp)
    {
        mHp = hp;
    }

    public void SetMaxHp(int maxHp)
    {
        mMaxHp = maxHp;
        mHp = maxHp;
    }

    public void ResetHp(int hp)
    {
        mMaxHp = hp;
        mHp = hp;
    }

    public void SetFinalAttack(int value) => mFinalAttack = value;
    public void SetFinalDefense(int value) => mFinalDefense = value;
    public void SetRuntimeMaxHp(int value) => mMaxHp = value;
}

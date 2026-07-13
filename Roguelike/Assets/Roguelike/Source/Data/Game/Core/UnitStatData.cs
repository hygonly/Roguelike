using UnityEngine;

public class UnitStatData : StatData
{
    public int MaxHp => mMaxHp;
    public int Hp => mHp;
    public double FinalAttack => mFinalAttack;
    public double FinalDefense => mFinalDefense;

    protected int mMaxHp;
    protected int mHp;

    protected double mFinalAttack;
    protected double mFinalDefense;

    public void SetMaxHp(int _maxHp)
    {
        mMaxHp = _maxHp;
        mHp = _maxHp;
    }

    public void SetHp(int _hp)
    {
        mHp = _hp;
    }

    public void ResetHp()
    {
        mHp = mMaxHp;
    }

    public void SetFianlAttack(double _value)
    {
        mFinalAttack = _value;
    }

    public void SetFianlDefense(double _value)
    {
        mFinalDefense = _value;
    }
}

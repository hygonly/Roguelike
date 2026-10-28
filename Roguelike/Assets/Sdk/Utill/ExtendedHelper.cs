using UnityEngine;

public static partial class ExtendedHelper
{
    public const int MS_PER_SECONDS = 1000;

    public static double From1000(this long _value)
    {
        return _value / 1000d;
    }

    public static double From10000(this long _value)
    {
        return _value / 10000d;
    }

    public static int MillisPerSecond(this int _second)
    {
        return _second * MS_PER_SECONDS;
    }

    public static bool IsValid(this Component _target)
    {
        return _target != null && _target.gameObject != null;
    }

    public static bool IsVaild(this GameObject _target)
    {
        return _target != null && _target.activeInHierarchy == true;
    }
}

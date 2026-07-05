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

    public static int MillisPerSecond(this int second)
    {
        return second * MS_PER_SECONDS;
    }

    public static bool IsObjectValid(this Component target)
    {
        return target != null && target.gameObject != null;
    }
}

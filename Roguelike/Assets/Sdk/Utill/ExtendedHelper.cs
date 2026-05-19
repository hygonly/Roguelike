using UnityEngine;

public static partial class ExtendedHelper
{
    public const int MS_PER_SECONDS = 1000;

    public static int MillisPerSecond(this int second)
    {
        return second * MS_PER_SECONDS;
    }
}

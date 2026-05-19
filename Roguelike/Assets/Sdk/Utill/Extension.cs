using UnityEngine;

public static class Extension
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        return Utills.GetOrAddComponent<T>(go);
    }

    public static T FindChild<T>(this GameObject go, string name = null, bool recursive = false, bool includeInActive = false) where T : Object
    {
        return FindChild<T>(go, name, recursive, includeInActive);
    }
}

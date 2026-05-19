using UnityEngine;

public class Utills
{
    public static T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();

        return component;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false, bool includeInActive = false) where T : Object
    {
        if (recursive == true)
        {
            foreach (T component in go.GetComponentsInChildren<T>(includeInActive))
            {
                if (string.IsNullOrEmpty(name) == true || name == component.name)
                    return component;
            }
        }
        else
        {
            Transform transform = go.transform;
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                T component = child.GetComponent<T>();
                if (component != null)
                {
                    if (string.IsNullOrEmpty(name) || name == child.name)
                        return component;
                }
            }
        }

        return null;
    }
}

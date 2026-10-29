using UnityEngine;
using UnityEngine.InputSystem;

public partial class LocalData
{
    public enum KeyType
    {
        None,
    }

    public bool HasKey(KeyType _key) => PlayerPrefs.HasKey(_key.ToString());

    public void DeleteKey(KeyType _key)
    {
        if (HasKey(_key) == false)
            return;

        PlayerPrefs.DeleteKey(_key.ToString());
    }

    public void DeleteAll()
    {
        var keyNames = typeof(KeyType).GetEnumNames();
        foreach (var keyName in keyNames)
            PlayerPrefs.DeleteKey(keyName);
    }

    public static int GetInt(KeyType _keyType, int _defaultValue = 0) => PlayerPrefs.GetInt(_keyType.ToString(), _defaultValue);
    public static float GetFloat(KeyType _keyType, float _defaultValue = 0f) => PlayerPrefs.GetFloat(_keyType.ToString(), _defaultValue);
    public static string GetString(KeyType _keyType, string _defaultValue = "") => PlayerPrefs.GetString(_keyType.ToString(), _defaultValue);

    public static void SetInt(KeyType _keyType, int _value = 0) => PlayerPrefs.SetInt(_keyType.ToString(), _value);
    public static void SetFloat(KeyType _keyType, float _value = 0f) => PlayerPrefs.SetFloat(_keyType.ToString(), _value);
    public static void SetString(KeyType _keyType, string _value = "") => PlayerPrefs.SetString(_keyType.ToString(), _value);
}

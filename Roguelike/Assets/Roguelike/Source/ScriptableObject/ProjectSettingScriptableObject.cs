using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "ProjectSetting", menuName = "ScriptableObjects/ProjectSetting")]
public class ProjectSettingScriptableObject : ScriptableObject
{
    private const string SettingFolderPath = "Assets/Resources";
    private const string settingFilePath = "Assets/Resources/ProjectSetting.asset";

    public static ProjectSettingScriptableObject Instance
    {
        get
        {
            if (mInstance != null)
                return mInstance;
            mInstance = Resources.Load<ProjectSettingScriptableObject>("ProjectSetting");
#if UNITY_EDITOR
            if (mInstance == null)
            {
                if (!AssetDatabase.IsValidFolder(SettingFolderPath))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }

                mInstance = AssetDatabase.LoadAssetAtPath<ProjectSettingScriptableObject>(settingFilePath);
                if (mInstance == null)
                {
                    mInstance = CreateInstance<ProjectSettingScriptableObject>();
                    AssetDatabase.CreateAsset(mInstance, settingFilePath);
                }
            }
#endif
            return mInstance;
        }
    }

    private static ProjectSettingScriptableObject mInstance;

    public InputActionAsset InputAsset => mInputActionAsset;

    [SerializeField] private InputActionAsset mInputActionAsset;
}

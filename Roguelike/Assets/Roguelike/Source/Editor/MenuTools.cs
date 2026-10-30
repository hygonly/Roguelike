using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MenuTools
{
    [MenuItem("Tools/Play")]
    public static void Play()
    {
        if (Application.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorSceneManager.OpenScene("Assets/Resources/Scenes/StartScene.unity");
        EditorApplication.isPlaying = true;
    }
}

using UnityEngine;

public class Config
{
    public const string DOWNLOAD_LABEL = "download";

    public const string ProjectName = "Roguelike";
    public const string DirPath = "Assets/" + ProjectName;

    public const string PrefabPath = DirPath + "/Prefab";
    public const string SpritePath = PrefabPath + "/ui";
    public const string EffectPath = PrefabPath + "/effect";
    public const string ScriptPath = PrefabPath + "/scripts_auto";
    public const string ScenePath = PrefabPath + "/scenes";

    public const int UPDATE_TICK_GAME_INTERVAL_MS = 20;
    public const float GAME_TICK_PERIOD_SECONDS = 0.02F;
    public const float INCREAMENT_NATURE_ABILITY = 1.1F;
    public const float DECREAMENT_NATURE_ABILITY = 0.9F;
}

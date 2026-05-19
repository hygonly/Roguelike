/********************************************************/
/*Auto Create File*/
/*Source: ExcelToJson*/
/********************************************************/

using Cysharp.Threading.Tasks;

public partial class JsonDataManager
{
    public int LoadCount { get { return _loadCount; } }
    public int MaxCount { get { return _maxCount;  } }

    private int _loadCount;
    private int _maxCount;

    public void Complete()
    {
        _loadCount++;
    }

    public float GetLoadProgress() { return (float)_loadCount / _maxCount; }

    public async UniTask LoadAll()
    {
        _loadCount = 0;
		ClearUserSettingScript();

        await UniTask.WhenAll(
			LoadUserSettingScript()
        );
    }
}
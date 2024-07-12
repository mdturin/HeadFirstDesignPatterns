namespace Singleton;

public class GlobalSettings
{
    private GlobalSettings() { }
    private static GlobalSettings? _instance;
    private static readonly object _lock = new();
    public static GlobalSettings GetInstance()
    {
        if(_instance == null)
        {
            lock (_lock)
            {
                _instance ??= new GlobalSettings();
            }
        }

        return _instance;
    }
}

using Newtonsoft.Json;

namespace ConfigurationManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        var settings = Settings.GetInstance();
        Console.WriteLine(settings.GetValue<string>("Name"));
    }
}

public class Settings
{
    private readonly object _lock = new();
    private Dictionary<string, object> AppSettings { get; set; }
    private const string _appSettingsFileName = "AppSettings.json";
    private static readonly Lazy<Settings> _instance
        = new(() => new Settings());

    private Settings() => Load(false);
    
    private void Load(bool reload)
    {
        try
        {
            using StreamReader sr = new(_appSettingsFileName);
            AppSettings = JsonConvert
                .DeserializeObject<Dictionary<string, object>>(sr.ReadToEnd())!;
        }
        catch (Exception ex)
        {
            if(!reload) AppSettings = [];
            Console.WriteLine($"Error reading {_appSettingsFileName}: {ex.Message}");
        }
    }

    public static Settings GetInstance() => _instance.Value;
    
    public T? GetValue<T>(string key)
    {
        lock (_lock)
        {
            if (!AppSettings.ContainsKey(key))
                return default;

            AppSettings.TryGetValue(key, out var value);
            return value is T _value ? _value : default;
        }
    }

    public void SetValue(string key, object value)
    {
        lock (_lock)
        {
            if (AppSettings.TryAdd(key, value))
                AppSettings[key] = value;
        }
    }

    public void Reload()
    {
        lock (_lock)
        {
            Load(true);
        }
    }
}
using Intermediate_Generic_Implementation.Classes.Interface;

namespace Intermediate_Generic_Implementation.Classes;

public class ConfigManager<T> where T : new()
{
    private readonly IConfigLoader<T> _loader;
    private T _settings;

    public ConfigManager(IConfigLoader<T> loader)
    {
        _loader = loader;
        _settings = new T();
    }

    public T GetSettings()
    {
        return _settings;
    }

    public void UpdateSettings(T newSettings)
    {
        _settings = newSettings;
    }
    
    public void SaveCurrentSettings()
    {
        _loader.SaveConfig(_settings);
    }
}
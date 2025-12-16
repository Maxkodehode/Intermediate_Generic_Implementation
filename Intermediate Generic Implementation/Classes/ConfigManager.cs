using Intermediate_Generic_Implementation.Classes.Interface;

namespace Intermediate_Generic_Implementation.Classes;

// Define the generic manager class (T is the settings type)
public class ConfigManager<T>
    // Constraint: T must have a parameterless constructor
    where T : new()
{
    // Private field to hold the I/O worker (the dependency)
    private readonly IConfigLoader<T> _loader;

    // Private field to hold the current settings state
    private T _settings;

    // Constructor that receives the loader
    public ConfigManager(IConfigLoader<T> loader)
    {
        // Store the provided loader instance
        _loader = loader;
        // Initialize the settings to a default value of type T
        _settings = new T();
    }

    // Method to get the current settings
    public T GetSettings()
    {
        // Return the current settings object
        return _settings;
    }

    // Method to replace the internal settings state
    public void UpdateSettings(T newSettings)
    {
        // Update the internal settings reference
        _settings = newSettings;
    }

    // Method to trigger the save operation
    public void SaveCurrentSettings()
    {
        // Delegate the save job to the _loader, passing the current settings
        _loader.SaveConfig(_settings);
    }
}

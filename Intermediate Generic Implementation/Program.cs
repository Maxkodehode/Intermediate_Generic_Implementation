// Import ConfigLoader and ConfigManager classes
using Intermediate_Generic_Implementation.Classes;
// Import IConfigLoader interface
using Intermediate_Generic_Implementation.Classes.Interface;

// Define the application namespace
namespace Intermediate_Generic_Implementation;

internal static class Program
{
    public static void Main()
    {
        // Create I/O worker (Loader); T is GameSettings
        IConfigLoader<GameSettings> loader = new ConfigLoader<GameSettings>();

        // Create Manager, injects the loader dependency
        var configManager = new ConfigManager<GameSettings>(loader);

        // Load the initial settings from the file
        GameSettings initialSettings = loader.LoadConfig();

        // Update the manager's internal settings'
        configManager.UpdateSettings(initialSettings);

        Console.WriteLine("\nSettings Before Change");

        // Print the initial settings
        Console.WriteLine(configManager.GetSettings().ToString());

        // Create a new GameSettings object
        var newSettings = new GameSettings
        {
            Volume = 40,
            Difficulty = "Insane",
            Language = "English",
            Fullscreen = true,
        };
        // Update the manager's internal settings with new data
        configManager.UpdateSettings(newSettings);

        // Tell the manager to save its current settings state
        configManager.SaveCurrentSettings();

        Console.WriteLine("\n--- Verifying Saved Settings ---");

        // Create a new loader to simulate a fresh load
        IConfigLoader<GameSettings> secondLoader = new ConfigLoader<GameSettings>();

        // Create a new manager for verification
        var verificationManager = new ConfigManager<GameSettings>(secondLoader);

        // Read the saved settings from the GameSettings.json file
        var loadedSettings = secondLoader.LoadConfig();

        // Update the verification manager's state
        verificationManager.UpdateSettings(loadedSettings);

        Console.WriteLine("\nSettings loaded from GameSettings.json:");

        // Print the content of the latest settings
        Console.WriteLine(loadedSettings.ToString());
    }
}

using Intermediate_Generic_Implementation.Classes;
using Intermediate_Generic_Implementation.Classes.Interface;

namespace Intermediate_Generic_Implementation;

internal static class Program
{
    public static void Main()
    {
        IConfigLoader<GameSettings> loader = new ConfigLoader<GameSettings>();

        var configManager = new ConfigManager<GameSettings>(loader);

        var newSettings = new GameSettings
        {
            Volume = 80,
            Difficulty = "Ultimate",
            Language = "Norwegian",
            Fullscreen = true,
        };

        configManager.UpdateSettings(newSettings);
        configManager.SaveCurrentSettings();

        Console.WriteLine("\n--- Verifying Saved Settings ---");

        IConfigLoader<GameSettings> secondLoader = new ConfigLoader<GameSettings>();
        var verificationManager = new ConfigManager<GameSettings>(secondLoader);

        GameSettings loadedSettings = secondLoader.LoadConfig();

        verificationManager.UpdateSettings(loadedSettings);

        // Display the data loaded from the file
        Console.WriteLine("Settings loaded from GameSettings.json:");
        Console.Clear();
        Console.WriteLine(loadedSettings.ToString());
    }
}

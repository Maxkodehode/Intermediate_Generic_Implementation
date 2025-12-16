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
            Volume = 75,
            Difficulty = "Insane",
            Language = "English",
            Fullscreen = false,
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

        Console.WriteLine(loadedSettings.ToString());
    }
}

using Intermediate_Generic_Implementation.Classes;
using Intermediate_Generic_Implementation.Classes.Interface;

namespace Intermediate_Generic_Implementation;

internal static class Program
{
    public static void Main()
    {
        
        var settings = new GameSettings { Volume = 75, Difficulty = "Hard", Language = "Spanish", Fullscreen = true };
    
        IConfigLoader<GameSettings> loader = new ConfigLoader<GameSettings>();
    
        var configManager = new ConfigManager<GameSettings>(loader);
    
        configManager.UpdateSettings(settings);
        configManager.SaveCurrentSettings();
        
        GameSettings currentSettings = configManager.GetSettings(); 
        Console.WriteLine(currentSettings);
        
        
    }
}
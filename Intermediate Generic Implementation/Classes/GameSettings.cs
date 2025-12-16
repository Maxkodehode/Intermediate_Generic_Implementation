namespace Intermediate_Generic_Implementation.Classes;

public class GameSettings
{
    // Settings properties for GameSettings
    public int Volume { get; init; }
    public string Difficulty { get; init; }
    public bool Fullscreen { get; init; }
    public string Language { get; init; }

    // Default constructor for GameSettings
    public GameSettings()
    {
        Volume = 50;
        Difficulty = "Normal";
        Fullscreen = false;
        Language = "English";
    }

    // Override the ToString() method for custom output
    public override string ToString()
    {
        // Returns a formatted string of settings
        return $"\n[GameSettings]\n\n Volume: {Volume},\n Difficulty: {Difficulty},\n Language: {Language},\n Fullscreen: {Fullscreen}";
    }
}

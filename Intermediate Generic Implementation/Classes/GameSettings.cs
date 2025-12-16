namespace Intermediate_Generic_Implementation.Classes;

public class GameSettings
{
    public int Volume { get; init; }
    public string Difficulty { get; init; }
    public bool Fullscreen { get; init; }
    public string Language { get; init; }

    public GameSettings()
    {
        Volume = 50;
        Difficulty = "Normal";
        Fullscreen = false;
        Language = "English";
    }

    public override string ToString()
    {
        // return GameSettings.ToString();
        return $"\n[GameSettings]\n\n Volume: {Volume},\n Difficulty: {Difficulty},\n Language: {Language},\n Fullscreen: {Fullscreen}";
    }
}

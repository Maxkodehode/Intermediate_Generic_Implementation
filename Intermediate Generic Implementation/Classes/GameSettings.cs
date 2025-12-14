namespace Intermediate_Generic_Implementation.Classes;

public class GameSettings
{
    public int Volume { get; set; } = 50;
    public string Difficulty { get; set; } = "Normal";
    public bool Fullscreen { get; set; } = false;
    public string Language { get; set; } = "English";
    
    public override string ToString()
    {
        // return GameSettings.ToString();
        return $"\n[GameSettings]\n\n Volume: {Volume},\n Difficulty: {Difficulty},\n Language: {Language},\n Fullscreen: {Fullscreen}";
    }
}
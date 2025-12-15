using System.IO;
using System.Text.Json;
using Intermediate_Generic_Implementation.Classes.Interface;

namespace Intermediate_Generic_Implementation.Classes;

public class ConfigLoader<T> : IConfigLoader<T>
    where T : new()
{
    private static string GetFilePath()
    {
        return $"{typeof(T).Name}.json";
    }

    public T LoadConfig()
    {
        string filePath = GetFilePath();
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"No config file found at {filePath}. Creating a new one...");
            return new T();
        }

        try
        {
            string jsonString = File.ReadAllText(filePath);

            T? config = JsonSerializer.Deserialize<T>(jsonString);

            Console.WriteLine($"Loaded config from {filePath}:");

            return config ?? new T();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading config from {filePath}: {e.Message}");
            return new T();
        }
    }

    public void SaveConfig(T config)
    {
        string filePath = GetFilePath();

        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(config, options);

            File.WriteAllText(filePath, jsonString);

            Console.WriteLine($"[ConfigLoader] Successfully saved {typeof(T).Name} to {filePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ConfigLoader] Error saving config: {ex.Message}");
        }
    }
}

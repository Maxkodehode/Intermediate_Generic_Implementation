// Import library for file operations (reading/writing)
using System.IO;
// Import library for JSON serialization
using System.Text.Json;
// Import IConfigLoader interface
using Intermediate_Generic_Implementation.Classes.Interface;

namespace Intermediate_Generic_Implementation.Classes;

// Define the concrete generic class, implements the contract
public class ConfigLoader<T> : IConfigLoader<T>
    // Constraint: T must have a parameterless constructor
    where T : new()
{
    // Private method to construct the config file path/name
    private static string GetFilePath()
    {
        // Returns the file name (e.g., "GameSettings.json")
        return $"{typeof(T).Name}.json";
    }

    // Implementation: loads config from the file system
    public T LoadConfig()
    {
        // Get the configuration file path
        string filePath = GetFilePath();
        // Check if the config file exists
        if (!File.Exists(filePath))
        {
            // Inform user a new default is created
            Console.WriteLine($"\nNo config file found at {filePath}. Creating a new one...");
            // Return a new, default instance of T
            return new T();
        }

        // Start an error handling block
        try
        {
            // Read the entire file content into a JSON string
            string jsonString = File.ReadAllText(filePath);

            // Convert the JSON string back into a T object (deserialization)
            T? config = JsonSerializer.Deserialize<T>(jsonString);

            // Inform user the file was loaded
            Console.WriteLine($"\nLoaded config from {filePath}:");

            // Return the loaded config, or a default T if null
            return config ?? new T();
        }
        // Catch any error during the load process
        catch (Exception e)
        {
            // Log the error message
            Console.WriteLine($"\nError loading config from {filePath}: {e.Message}");
            // Return a default T to prevent crash
            return new T();
        }
    }

    // Implementation: saves config to the file system
    public void SaveConfig(T config)
    {
        // Get the configuration file path
        string filePath = GetFilePath();

        // Start an error handling block
        try
        {
            // Create options for readable (indented) JSON
            var options = new JsonSerializerOptions { WriteIndented = true };
            // Convert the T object (config) into a formatted JSON string
            string jsonString = JsonSerializer.Serialize(config, options);

            // Write the JSON string to the file
            File.WriteAllText(filePath, jsonString);

            // Log successful save
            Console.WriteLine(
                $"\n[ConfigLoader] Successfully saved {typeof(T).Name} to {filePath}."
            );
        }
        // Catch any error during the save process
        catch (Exception ex)
        {
            // Log the error message
            Console.WriteLine($"\n[ConfigLoader] Error saving config: {ex.Message}");
        }
    }
}

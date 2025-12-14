
using Intermediate_Generic_Implementation.Classes.Interface;

namespace Intermediate_Generic_Implementation.Classes;

public class ConfigLoader<T> : IConfigLoader<T> where T : new()
{
    public T LoadConfig()
    {
        Console.WriteLine($"Simulating loading {typeof(T).Name} from a JSON file...");
        return new T();
    }


    public void SaveConfig(T config)
    {
        Console.WriteLine($"Simulating saving {typeof(T).Name} to a JSON file...");
    }

}
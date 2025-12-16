// Define the namespace for the interfaces
namespace Intermediate_Generic_Implementation.Classes.Interface;

// Define a generic interface
public interface IConfigLoader<T>
{
    // Requires a method to load config and return type T
    T LoadConfig();

    // Requires a method to save config of type T
    void SaveConfig(T config);
}

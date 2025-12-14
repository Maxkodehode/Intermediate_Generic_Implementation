

namespace Intermediate_Generic_Implementation.Classes.Interface;

public interface IConfigLoader<T>
{
    T LoadConfig();
    void SaveConfig(T config);
}
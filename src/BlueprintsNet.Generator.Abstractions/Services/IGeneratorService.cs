using BlueprintsNet.Core.Models.Classes;

namespace BlueprintsNet.Generator.Services;

public interface IGeneratorService
{
    void GenerateClass(Class @class);
}

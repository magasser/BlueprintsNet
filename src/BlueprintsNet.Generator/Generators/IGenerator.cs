
namespace BlueprintsNet.Generator.Generators;

internal interface IGenerator<T>
{
    string Generate(T value);
}

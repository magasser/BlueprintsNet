
namespace BlueprintsNet.Core.Models;

public interface IInstanceValue : IValue
{
    string Name { get; set; }

    AccessModifier AccessModifier { get; set; }
}


namespace BlueprintsNet.Core.Models;

public interface IInstanceValue<T> : IValue<T>
{
    AccessModifier AccessModifier { get; set; }
}

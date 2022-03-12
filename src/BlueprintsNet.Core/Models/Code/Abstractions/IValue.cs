
namespace BlueprintsNet.Core.Models;

public interface IValue<T>
{
    public Type Type { get; }

    public T Value { get; set; }
}


namespace BlueprintsNet.Core.Models;

public abstract class ValueBase<T> : IValue<T>
{
    protected ValueBase(T value)
    {
        Value = value;
    }

    public Type Type => typeof(T);

    public T Value { get; set; }
}


namespace BlueprintsNet.Core.Models;

public class Field<T> : InstanceValueBase<T>
{
    public Field(AccessModifier accessModifier, T value)
        : base(accessModifier, value)
    {
    }

    public bool IsStatic { get; private set; }

    public bool IsReadonly { get; private set; }

    public bool IsConstant { get; private set; }

    public bool CanBeConstant => Type.IsValueType;

    public bool TrySetStatic(bool isStatic)
    {
        if (isStatic && IsConstant)
        {
            return false;
        }

        IsStatic = isStatic;
        return true;
    }

    public bool TrySetReadonly(bool isReadonly)
    {
        if (isReadonly && IsConstant)
        {
            return false;
        }

        IsReadonly = isReadonly;
        return true;
    }

    public bool TrySetConstant(bool isConstant)
    {
        if (!CanBeConstant)
        {
            return false;
        }

        if (isConstant)
        {
            IsStatic = false;
            IsReadonly = false;
        }

        IsConstant = isConstant;
        return true;
    }
}


namespace BlueprintsNet.Core.Models.Classes;

public record Field
{
    public Field(string name,
                 AccessModifier accessModifier,
                 string type)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();
        Type = type.MustNotBeNullOrWhiteSpace();
    }

    public string Name { get; set; }

    public string Type { get; set; }

    public AccessModifier AccessModifier { get; set; }

    public bool IsStatic { get; private set; }

    public bool IsReadonly { get; private set; }

    public bool IsConstant { get; private set; }

    public bool TrySetStatic(bool isStatic)
    {
        if (isStatic && IsConstant)
            return false;

        IsStatic = isStatic;
        return true;
    }

    public bool TrySetReadonly(bool isReadonly)
    {
        if (isReadonly && IsConstant)
            return false;

        IsReadonly = isReadonly;
        return true;
    }

    public bool TrySetConstant(bool isConstant)
    {
        if (isConstant)
        {
            IsStatic = false;
            IsReadonly = false;
        }

        IsConstant = isConstant;
        return true;
    }
}


namespace BlueprintsNet.Core.Models.Classes;

public record Field
{
    private readonly List<BPGet> _getReferences;
    private readonly List<BPSet> _setReferences;

    public Field(string name,
                 AccessModifier accessModifier,
                 NodeType nodeType)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();
        NodeType = nodeType.MustBeValidEnumValue();

        _getReferences = new List<BPGet>();
        _setReferences = new List<BPSet>();
    }

    public string Name { get; set; }

    public NodeType NodeType { get; set; }

    public AccessModifier AccessModifier { get; set; }

    public bool IsStatic { get; private set; }

    public bool IsReadonly { get; private set; }

    public bool IsConstant { get; private set; }

    public IReadOnlyList<BPGet> GetReferences => _getReferences;

    public IReadOnlyList<BPSet> SetReferences => _setReferences;

    public BPGet CreateGetBlueprint()
    {
        var bp = new BPGet(this);

        _getReferences.Add(bp);

        return bp;
    }

    public BPSet CreateSetBlueprint()
    {
        var bp = new BPSet(this);

        _setReferences.Add(bp);

        return bp;
    }

    public bool DeleteGetBlueprint(BPGet bp)
    {
        return _getReferences.Remove(bp);
    }

    public bool DeleteSetBlueprint(BPSet bp)
    {
        return _setReferences.Remove(bp);
    }

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

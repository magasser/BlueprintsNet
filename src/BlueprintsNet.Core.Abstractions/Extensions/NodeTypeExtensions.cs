
namespace BlueprintsNet.Core.Domain;

public static class NodeTypeExtensions
{
    public static IOut ToOut(this NodeType nodeType,
                                        IBlueprint parent,
                                        string name,
                                        string? objectType = null)
    {
        nodeType.MustBeValidEnumValue();

        if (nodeType is NodeType.Object && string.IsNullOrWhiteSpace(objectType))
        {
            throw new ArgumentException($"Value cannot be null or whitespace when node type is {NodeType.Object}.", nameof(objectType));
        }

        return nodeType switch
        {
            NodeType.Bool => new Bool.Out(parent, name),
            NodeType.Integer => new Integer.Out(parent, name),
            NodeType.String => new Models.Blueprints.String.Out(parent, name),
            NodeType.Object => new Models.Blueprints.Object.Out(parent, name, objectType!),
            _ => throw new NotSupportedException($"The node type {nodeType} is not supported.")
        };
    }

    public static IIn ToIn(this NodeType nodeType,
                                      IBlueprint parent,
                                      string name,
                                      string? objectType = null)
    {
        nodeType.MustBeValidEnumValue();

        if (nodeType is NodeType.Object && string.IsNullOrWhiteSpace(objectType))
        {
            throw new ArgumentException($"Value cannot be null or whitespace when node type is {NodeType.Object}.", nameof(objectType));
        }

        return nodeType switch
        {
            NodeType.Bool => new Bool.In(parent, name),
            NodeType.Integer => new Integer.In(parent, name),
            NodeType.String => new Models.Blueprints.String.In(parent, name),
            NodeType.Object => new Models.Blueprints.Object.In(parent, name, objectType!),
            _ => throw new NotSupportedException($"The node type {nodeType} is not supported.")
        };
    }

    public static string GetBuiltInType(this NodeType nodeType)
    {
        nodeType.MustBeValidEnumValue();

        return nodeType switch
        {
            NodeType.Bool => "bool",
            NodeType.Integer => "int",
            NodeType.String => "string",
            _ => throw new NotSupportedException($"The node type {nodeType} is not supported.")
        };
    }
}

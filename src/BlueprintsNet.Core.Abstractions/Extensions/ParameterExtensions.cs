
namespace BlueprintsNet.Core.Models.Classes;

public static class ParameterExtensions
{
    public static IOut ToOut(this Parameter parameter, IBlueprint parent)
    {
        parameter.MustNotBeNull();
        parent.MustNotBeNull();

        var objectType = parameter is ObjectParameter objectParameter ? objectParameter.ObjectType : null;

        return parameter.NodeType
                        .ToOut(parent, parameter.Name, objectType);
    }

    public static IIn ToIn(this Parameter parameter, IBlueprint parent)
    {
        parameter.MustNotBeNull();
        parent.MustNotBeNull();

        var objectType = parameter is ObjectParameter objectParameter ? objectParameter.ObjectType : null;

        return parameter.NodeType
                        .ToIn(parent, parameter.Name, objectType);
    }
}


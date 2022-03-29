
namespace BlueprintsNet.Core.Models.Classes;

public static class FieldExtensions
{
    public static IOut ToOut(this Field field, IBlueprint parent)
    {
        field.MustNotBeNull();
        parent.MustNotBeNull();

        var objectType = field is ObjectField objectField ? objectField.ObjectType : null;

        return field.NodeType
                    .ToOut(parent, field.Name, objectType);
    }

    public static IIn ToIn(this Field field, IBlueprint parent)
    {
        field.MustNotBeNull();
        parent.MustNotBeNull();

        var objectType = field is ObjectField objectField ? objectField.ObjectType : null;

        return field.NodeType
                    .ToIn(parent, field.Name, objectType);
    }
}

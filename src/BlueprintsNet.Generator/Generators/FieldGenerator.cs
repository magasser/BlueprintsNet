
namespace BlueprintsNet.Generator.Generators;

internal class FieldGenerator : IGenerator<Field>
{
    public string Generate(Field value)
    {
        value.MustNotBeNull();

        if (value is ObjectField objectField)
        {
            return $"{value.AccessModifier.ToString().ToLower()} {objectField.ObjectType} {value.Name};";
        }

        return $"{value.AccessModifier.ToString().ToLower()} {value.NodeType.GetBuiltInType()} {value.Name};";
    }
}

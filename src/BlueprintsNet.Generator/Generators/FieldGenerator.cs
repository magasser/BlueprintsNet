
namespace BlueprintsNet.Generator.Generators;

internal class FieldGenerator : IGenerator<Field>
{
    public string Generate(Field value)
    {
        value.MustNotBeNull();

        return $"{value.AccessModifier.ToString().ToLower()} {value.Type} {value.Name};";
    }
}

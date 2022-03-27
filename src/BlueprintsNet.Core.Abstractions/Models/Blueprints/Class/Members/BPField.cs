
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPField : BPBase
{
    public BPField(Field field, IOutValue outValue)
    {
        Field = field.MustNotBeNull();
        OutValue = outValue.MustNotBeNull();

        DisplayName = Field.Name;
    }

    public override string DisplayName { get; init; }

    public IOutValue OutValue { get; init; }

    public Field Field { get; init; }
}

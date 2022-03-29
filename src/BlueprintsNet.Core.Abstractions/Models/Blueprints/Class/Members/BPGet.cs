
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPGet : BPBase
{
    public BPGet(Field field)
    {
        Field = field.MustNotBeNull();

        DisplayName = Field.Name;

        OutValue = Field.ToOut(this);
    }

    public override string DisplayName { get; init; }

    public IOut OutValue { get; init; }

    public Field Field { get; init; }
}

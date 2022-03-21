
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPPlus : BPArithmeticBase
{
    public BPPlus()
    {
        DisplayName = BPNames.Plus;
    }

    public override string DisplayName { get; init; }
}

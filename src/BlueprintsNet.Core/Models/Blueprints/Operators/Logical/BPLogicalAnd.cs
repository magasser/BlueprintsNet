
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPLogicalAnd : BPLogicalBase
{
    public BPLogicalAnd()
    {
        DisplayName = BPNames.And;
    }

    public override string DisplayName { get; init; }
}

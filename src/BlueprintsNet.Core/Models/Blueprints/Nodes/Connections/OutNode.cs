
namespace BlueprintsNet.Core.Models.Blueprints;

public class OutNode : NodeBase
{
    internal OutNode(string displayName) : base(displayName) { }

    public InNode? Next { get; set; }
}


namespace BlueprintsNet.Core.Models.Blueprints;

public interface IInValue : IValue, INode
{
    IOutValue? Previous { get; set; }
}

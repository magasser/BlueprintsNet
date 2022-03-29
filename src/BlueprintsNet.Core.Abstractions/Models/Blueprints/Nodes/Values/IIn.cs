
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IIn : IValue, INode
{
    IOut? Previous { get; set; }
}

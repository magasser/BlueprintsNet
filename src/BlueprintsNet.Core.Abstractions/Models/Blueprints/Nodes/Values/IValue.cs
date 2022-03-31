
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IValue
{
    NodeType DataType { get; }

    string ConstantValue { get; set; }
}

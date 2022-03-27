
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IValue
{
    DataType DataType { get; }

    string ConstantValue { get; set; }
}

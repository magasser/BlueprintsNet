
namespace BlueprintsNet.Core.Models;

public interface IMethod
{
    string Name { get; set; }

    AccessModifier AccessModifier { get; set; }

    List<Parameter> Parameters { get; }

    Return? ReturnValue { get; set; }
}


namespace BlueprintsNet.Core.Models.Blueprints;

public static class ParameterExtensions
{
    public static IOutValue GetInValue(this Parameter parameter, IBlueprint parent)
    {
        parameter.MustNotBeNull();

        return parameter.Type switch
        {
            var type when type == typeof(Bool) => new Bool.Out(parent, parameter.Name),
            var type when type == typeof(Integer) => new Integer.Out(parent, parameter.Name),
            var type when type == typeof(String) => new String.Out(parent, parameter.Name),
            var type when type == typeof(Object) && parameter is ObjectParameter objectParameter =>
                    new Object.Out(parent, objectParameter.Name, objectParameter.ObjectType),
            _ => throw new NotSupportedException($"The parameter type {parameter.Type} is not supported.")
        };
    }
}

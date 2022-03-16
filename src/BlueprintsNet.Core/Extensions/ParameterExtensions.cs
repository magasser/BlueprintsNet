
namespace BlueprintsNet.Core.Extensions;

internal static class ParameterExtensions
{
    public static IInValue GetInValue(this Parameter parameter)
    {
        parameter.MustNotBeNull();

        return parameter.Type switch
        {
            var type when type == typeof(Bool) => new Bool.In(parameter.Name),
            var type when type == typeof(Integer) => new Integer.In(parameter.Name),
            var type when type == typeof(Models.Blueprints.String) => new Models.Blueprints.String.In(parameter.Name),
            var type when (type == typeof(Models.Blueprints.Object)) && (parameter is ObjectParameter objectParameter) =>
                    new Models.Blueprints.Object.In(objectParameter.Name, objectParameter.ObjectType),
            _ => throw new NotSupportedException($"The parameter type {parameter.Type} is not supported.")
        };
    }
}

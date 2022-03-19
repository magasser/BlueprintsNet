
using Newtonsoft.Json;

namespace BlueprintsNet.Core.JsonConverters;

public class TypeJsonConverter : JsonConverter<Type>
{
    public override Type? ReadJson(JsonReader reader,
                                   Type objectType,
                                   Type? existingValue,
                                   bool hasExistingValue,
                                   JsonSerializer serializer)
    {
        return reader.Value as string switch
        {
            var typeName when typeName == typeof(Bool).FullName => typeof(Bool),
            var typeName when typeName == typeof(Integer).FullName => typeof(Integer),
            var typeName when typeName == typeof(Models.Blueprints.String).FullName => typeof(Models.Blueprints.String),
            var typeName when typeName == typeof(Models.Blueprints.Object).FullName => typeof(Models.Blueprints.Object),
            var typeName => throw new NotSupportedException($"The type name {typeName} is not supported.")
        };
    }

    public override void WriteJson(JsonWriter writer,
                                   Type? value,
                                   JsonSerializer serializer)
    {
        var typeString = value switch
        {
            var type when type == typeof(Bool) => typeof(Bool).FullName,
            var type when type == typeof(Integer) => typeof(Integer).FullName,
            var type when type == typeof(Models.Blueprints.String) => typeof(Models.Blueprints.String).FullName,
            var type when type == typeof(Models.Blueprints.Object) => typeof(Models.Blueprints.Object).FullName,
            var type => throw new NotSupportedException($"The type name {type?.FullName} is not supported.")
        };

        writer.WriteValue(typeString);
    }
}

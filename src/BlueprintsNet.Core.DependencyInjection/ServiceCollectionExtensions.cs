using Light.GuardClauses;
using BlueprintsNet.Core.Domain;
using BlueprintsNet.Core.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlueprintsNetCore(this IServiceCollection services, SerializerType serializerType)
    {
        services.MustNotBeNull();

        services.AddSingleton<IProjectService, ProjectService>()
            .AddSingleton<IFileService, FileService>();

        return serializerType switch
        {
            SerializerType.Xml => services.AddSingleton<ISerializerService, XmlSerializerService>(),
            _ => throw new NotSupportedException($"The serializer type {serializerType} is not supported.")
        };
    }
}

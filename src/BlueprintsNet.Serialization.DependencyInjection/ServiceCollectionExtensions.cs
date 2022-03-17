
using Light.GuardClauses;
using BlueprintsNet.Serialization.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlueprintsNetSerialization(this IServiceCollection services)
    {
        return services.MustNotBeNull()
                   .AddSingleton<ISerializationService, SerializationService>();
    }
}
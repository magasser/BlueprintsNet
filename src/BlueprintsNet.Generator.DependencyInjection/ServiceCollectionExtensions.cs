using Light.GuardClauses;
using BlueprintsNet.Generator.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlueprintsNetGenerator(this IServiceCollection services)
    {
        services.MustNotBeNull();

        services.AddSingleton<IClassGenerator, ClassGenerator>();

        return services;
    }
}


using Light.GuardClauses;
using BlueprintsNet.Core.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlueprintsNetCore(this IServiceCollection services)
    {
        return services.MustNotBeNull()
                   .AddSingleton<IProjectService, ProjectService>();
    }
}

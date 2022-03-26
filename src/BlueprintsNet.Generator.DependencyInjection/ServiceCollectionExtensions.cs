using BlueprintsNet.Generator.Services;
using BlueprintsNet.Generator.Generators;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlueprintsNetGenerator(this IServiceCollection services)
    {
        services.MustNotBeNull();

        services.AddSingleton<IGeneratorService, GeneratorService>()
            .AddSingleton<IGenerator<Class>, ClassGenerator>()
            .AddSingleton<IGenerator<Constructor>, ConstructorGenerator>()
            .AddSingleton<IGenerator<Field>, FieldGenerator>()
            .AddSingleton<IGenerator<Method>, MethodGenerator>()
            .AddSingleton<IBlueprintGenerator, BlueprintGenerator>();

        return services;
    }
}

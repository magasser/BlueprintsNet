using BlueprintsNet.Core.Services;
using BlueprintsNet.Generator.Generators;

namespace BlueprintsNet.Generator.Services;

internal class GeneratorService : IGeneratorService
{
    private readonly ILogger<GeneratorService> _logger;
    private readonly IGenerator<Class> _classGenerator;
    private readonly IFileService _fileService;

    public GeneratorService(ILogger<GeneratorService> logger,
                            IGenerator<Class> classGenerator,
                            IFileService fileService)
    {
        _logger = logger.MustNotBeNull();
        _classGenerator = classGenerator.MustNotBeNull();
        _fileService = fileService.MustNotBeNull();
    }

    public void GenerateClass(Class @class)
    {
        @class.MustNotBeNull();

        _logger.LogTrace("Try to generated class: {Class}.", @class);

        var classString = _classGenerator.Generate(@class);

        var path = Path.Combine(Folders.Output,
                                @class.FolderPath,
                                $"{@class.Name}.cs");

        _fileService.Write(path, classString);

        _logger.LogDebug("Generated class at {Path}: {ClassString}.", path, classString);
    }
}

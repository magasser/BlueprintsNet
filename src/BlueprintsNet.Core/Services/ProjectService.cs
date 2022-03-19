using BlueprintsNet.Core.Models.Files;
using BlueprintsNet.Core.Models.Project;

namespace BlueprintsNet.Core.Services;

internal class ProjectService : IProjectService
{
    private readonly ILogger<ProjectService> _logger;
    private readonly ISerializerService _serializerService;
    private readonly IFileService _fileService;

    public ProjectService(ILogger<ProjectService> logger,
                          ISerializerService serializerService,
                          IFileService fileService)
    {
        _logger = logger.MustNotBeNull();
        _serializerService = serializerService.MustNotBeNull();
        _fileService = fileService.MustNotBeNull();
    }

    public Class LoadClass(string path)
    {
        path.MustNotBeNullOrWhiteSpace();

        _logger.LogTrace("Load class from: {Path}.", path);

        var content = _fileService.Read(path);

        _logger.LogDebug("Read content: {Content}.", content);

        var classFile = _serializerService.Deserialize<ClassFile>(content);

        var @class = classFile.Class;

        _logger.LogInformation("Loaded class: {Class}", @class);

        return @class;
    }

    public void SaveClass(Class @class)
    {
        @class.MustNotBeNull();

        _logger.LogTrace("Save class: {Class}.", @class);

        var classFileInfo = new ClassFileInfo();

        _logger.LogDebug("Save with class file info: {ClassFileInfo}.", classFileInfo);

        var classFile = new ClassFile(classFileInfo, @class);

        var content = _serializerService.Serialize(classFile);

        _logger.LogDebug("Created content: {Content}.", content);

        _fileService.Write(@class.Path, content);

        _logger.LogInformation("Saved class: {Class}.", @class);
    }

    public Project LoadProject(string path)
    {
        throw new NotImplementedException();
    }

    public void SaveProject(Project project)
    {
        throw new NotImplementedException();
    }
}

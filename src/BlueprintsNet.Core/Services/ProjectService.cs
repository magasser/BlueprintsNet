using System.Configuration;
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

    public Project LoadProject(string path)
    {
        throw new NotImplementedException();
    }

    public void SaveProject(Project project)
    {
        throw new NotImplementedException();
    }

    public Class LoadClass(string path)
    {
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
        _logger.LogTrace("Save class: {Class}.", @class);

        var classSection = (NameValueConfigurationCollection)ConfigurationManager.GetSection(ConfigKeys.ClassSection);
        var fileExtension = classSection[ConfigKeys.ExtensionKey].Value;
        var version = new Version(classSection[ConfigKeys.VersionKey].Value);

        var classFileInfo = new ClassFileInfo(fileExtension, version);

        _logger.LogDebug("Save with class file info: {ClassFileInfo}.", classFileInfo);

        var classFile = new ClassFile(classFileInfo, @class);

        var content = _serializerService.Serialize(classFile);

        _logger.LogDebug("Created content: {Content}.", content);

        _fileService.Write(@class.Path, content);

        _logger.LogInformation("Saved class: {Class}.", @class);
    }
}

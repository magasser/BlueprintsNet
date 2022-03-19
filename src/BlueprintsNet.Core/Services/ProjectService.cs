using BlueprintsNet.Core.Files;

namespace BlueprintsNet.Core.Services;

internal class ProjectService : IProjectService
{
    private static readonly ClassFileInfo _classFileInfo = new();
    private static readonly ProjectFileInfo _projectFileInfo = new();

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

    public Class LoadClass(string name, string folderPath)
    {
        name.MustNotBeNullOrWhiteSpace();
        folderPath.MustNotBeNullOrWhiteSpace();

        var path = Path.Combine(folderPath, $"{name}.{_classFileInfo.Extension}");

        _logger.LogTrace("Try to load class from: {Path}.", path);

        var content = _fileService.Read(path);

        var classFile = _serializerService.Deserialize<ClassFile>(content);

        var @class = classFile.Class;

        _logger.LogInformation("Loaded class: {Class}", @class);

        return @class;
    }

    public void SaveClass(Class @class)
    {
        @class.MustNotBeNull();

        _logger.LogTrace("Try to save class: {Class}.", @class);

        var classFile = new ClassFile(_classFileInfo, @class);

        var content = _serializerService.Serialize(classFile);

        var path = Path.Combine(@class.FolderPath, $"{@class.Name}.{_classFileInfo.Extension}");

        _fileService.Write(path, content);

        _logger.LogDebug("Saved class: {Class}.", @class);
    }

    public Project LoadProject(string name, string folderPath)
    {
        name.MustNotBeNullOrWhiteSpace();
        folderPath.MustNotBeNullOrWhiteSpace();

        var path = Path.Combine(folderPath, $"{name}.{_projectFileInfo.Extension}");

        _logger.LogTrace("Try to load project from: {Path}.", path);

        var content = _fileService.Read(path);

        var projectFile = _serializerService.Deserialize<ProjectFile>(content);

        var project = projectFile.Project;

        _logger.LogInformation("Loaded project: {Project}", project);

        return project;
    }

    public void SaveProject(Project project)
    {
        project.MustNotBeNull();

        _logger.LogTrace("Try to save project: {Project}.", project);

        var projectFile = new ProjectFile(_projectFileInfo, project);

        var content = _serializerService.Serialize(projectFile);

        var path = Path.Combine(project.FolderPath, $"{project.Name}.{_projectFileInfo.Extension}");

        _fileService.Write(path, content);

        _logger.LogDebug("Saved project: {Project}.", project);
    }
}

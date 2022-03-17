
namespace BlueprintsNet.Core.Services;

internal class ProjectService : IProjectService
{
    private readonly ILogger<ProjectService> _logger;

    public ProjectService(ILogger<ProjectService> logger)
    {
        _logger = logger.MustNotBeNull();
    }

    public Project LoadProject(string projectPath)
    {
        throw new NotImplementedException();
    }

    public void SaveClass(Class @class)
    {
        throw new NotImplementedException();
    }
}

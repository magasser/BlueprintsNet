using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BlueprintsNet.Core.Files;
using BlueprintsNet.Core.Domain;
using BlueprintsNet.Core.Services;
using BlueprintsNet.Core.JsonConverters;
using BlueprintsNet.Core.Models.Classes;
using BlueprintsNet.Core.Models.Projects;
using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Core.IntegrationTests;

[TestFixture]
public class ProjectHandlingIntegrationTests
{
    private const string ProjectDirectoryPath = "Project";
    private const string ClassName = "TestClass";
    private const string ProjectName = "TestProject";
    private string _classFilePath;
    private string _projectFilePath;

    private IProjectService _projectService;

    [SetUp]
    public void Setup()
    {
        var fileLogger = NullLogger<FileService>.Instance;
        var serializerLogger = NullLogger<JsonSerializerService>.Instance;
        var projectLogger = NullLogger<ProjectService>.Instance;

        var jsonConverters = new List<JsonConverter> { new TypeJsonConverter(), new StringEnumConverter() };

        var fileService = new FileService(fileLogger);
        var serializerService = new JsonSerializerService(serializerLogger, jsonConverters);

        _projectService = new ProjectService(projectLogger, serializerService, fileService);

        _classFilePath = $"{ProjectDirectoryPath}\\{ClassName}.{new ClassFileInfo().Extension}";
        _projectFilePath = $"{ProjectDirectoryPath}\\{ProjectName}.{new ProjectFileInfo().Extension}";


        Directory.CreateDirectory(ProjectDirectoryPath);
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(_classFilePath);
        File.Delete(_projectFilePath);
        Directory.Delete(ProjectDirectoryPath);
    }

    [Test]
    public void Saving_and_then_loading_class_Should_create_class_file_And_load_equivalent_class()
    {
        // Arrange
        var @class = new Class(ClassName, ProjectDirectoryPath, AccessModifier.Public);

        var methodWithBlueprints = new Method("SomeMethod1", AccessModifier.Public);
        methodWithBlueprints.Start.InValues
            .Add(new Bool.In("boolIn1"));
        methodWithBlueprints.Start.InValues
            .Add(new Bool.In("boolIn2"));
        methodWithBlueprints.Start.InValues
            .Add(new Models.Blueprints.Object.In("objectIn", "Test"));
        methodWithBlueprints.Blueprints
            .Add(new BPLogicalAnd());
        methodWithBlueprints.Return.OutValue = new Bool.Out("boolOut");

        @class.Constructors
            .Add(new Constructor(@class.Name, AccessModifier.Public));
        @class.Methods
            .AddRange(new Method[] { methodWithBlueprints, new Method("SomeMethod2", AccessModifier.Private) });
        @class.Fields
            .AddRange(new Field[]
            {
                new Field("SomeField1", AccessModifier.Public, typeof(Bool)),
                new Field("SomeField2", AccessModifier.Private, typeof(Models.Blueprints.String))
            });
        // Act
        _projectService.SaveClass(@class);
        var loadedClass = _projectService.LoadClass(@class.Name, ProjectDirectoryPath);

        // Assert
        var classFileExists = File.Exists(_classFilePath);

        classFileExists.Should()
            .BeTrue();

        loadedClass.Should()
            .BeEquivalentTo(@class);
    }

    [Test]
    public void Saving_and_then_loading_project_Should_create_project_file_And_load_equivalent_project()
    {
        // Arrange
        var @class = new Class(ClassName, ProjectDirectoryPath, AccessModifier.Public);

        var methodWithBlueprints = new Method("SomeMethod1", AccessModifier.Public);
        methodWithBlueprints.Start.InValues
            .Add(new Bool.In("boolIn1"));
        methodWithBlueprints.Start.InValues
            .Add(new Bool.In("boolIn2"));
        methodWithBlueprints.Start.InValues
            .Add(new Models.Blueprints.Object.In("objectIn", "Test"));
        methodWithBlueprints.Blueprints
            .Add(new BPLogicalAnd());
        methodWithBlueprints.Return.OutValue = new Bool.Out("boolOut");

        @class.Constructors
            .Add(new Constructor(@class.Name, AccessModifier.Public));
        @class.Methods
            .AddRange(new Method[] { methodWithBlueprints, new Method("SomeMethod2", AccessModifier.Private) });
        @class.Fields
            .AddRange(new Field[]
            {
                new Field("SomeField1", AccessModifier.Public, typeof(Bool)),
                new Field("SomeField2", AccessModifier.Private, typeof(Models.Blueprints.String))
            });

        var project = new Project(new Guid("4BA267AD-5341-4085-8E7F-3C1EA2CFD2A7"),
                                  ProjectName,
                                  ProjectDirectoryPath,
                                  new List<Class> { @class });
        // Act
        _projectService.SaveProject(project);
        var loadedProject = _projectService.LoadProject(project.Name, ProjectDirectoryPath);

        // Assert
        var projectFileExists = File.Exists(_projectFilePath);

        projectFileExists.Should()
            .BeTrue();

        loadedProject.Should()
            .BeEquivalentTo(project);
    }
}
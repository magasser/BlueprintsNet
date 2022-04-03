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
    public void Saving_and_then_loading_project_Should_create_project_file_And_load_equivalent_project()
    {
        // Arrange
        var @class = new Class(ClassName,
                               ProjectName,
                               ProjectDirectoryPath,
                               AccessModifier.Public);

        // Value connections
        var method = new ObjectMethod("MethodTest", AccessModifier.Public, "Test");
        var field = new Field("intField", AccessModifier.Public, NodeType.Integer);
        var toUpMethod = new Method("ToUp", AccessModifier.Public, NodeType.String);
        var addStrMethod = new Method("AddStr", AccessModifier.Public, NodeType.String);
        var testConstructor = new Constructor("Test", AccessModifier.Public);
        method.AddParameter(new Parameter("stringIn", NodeType.String));
        method.AddParameter(new Parameter("boolIn", NodeType.Bool));
        method.AddParameter(new Parameter("intIn", NodeType.Integer));
        toUpMethod.AddParameter(new Parameter("stringIn", NodeType.String));
        addStrMethod.AddParameter(new Parameter("stringIn", NodeType.String));
        addStrMethod.AddParameter(new Parameter("intIn", NodeType.Integer));
        testConstructor.AddParameter(new Parameter("stringIn", NodeType.String));
        var strIn = method.Start.Parameters[0];
        var boolIn = method.Start.Parameters[1];
        var intIn = method.Start.Parameters[2];
        var ifStatement = new BPIf();
        var plusStatement = new BPPlus();
        var toUpStatement = toUpMethod.CreateBlueprint();
        var addStrStatement = addStrMethod.CreateBlueprint();
        var getStatement = field.CreateGetBlueprint();
        var testConstructorIf = testConstructor.CreateBlueprint();
        var testConstructorElse = testConstructor.CreateBlueprint();
        var returnIf = method.CreateReturn();
        var returnElse = method.CreateReturn();
        ifStatement.Condition.Previous = boolIn;
        plusStatement.In1.Previous = strIn;
        plusStatement.In2.Previous = getStatement.OutValue;
        toUpStatement.Parameters[0].Previous = strIn;
        addStrStatement.Parameters[0].Previous = strIn;
        addStrStatement.Parameters[1].Previous = intIn;
        testConstructorIf.Parameters[0].Previous = toUpStatement.OutValue;
        testConstructorElse.Parameters[0].Previous = addStrStatement.OutValue;
        returnIf.ReturnValue.Previous = testConstructorIf.OutValue;
        returnElse.ReturnValue.Previous = testConstructorElse.OutValue;

        // Flow connections
        method.Start.Out.Next = ifStatement.In;
        ifStatement.OutTrue.Next = returnIf.In;
        ifStatement.OutFalse.Next = returnElse.In;

        @class.Constructors
              .Add(testConstructor);
        @class.Methods
              .AddRange(new Method[] { method, toUpMethod, addStrMethod });
        @class.Fields
              .Add(field);

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
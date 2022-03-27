using BlueprintsNet.Core;
using BlueprintsNet.Core.Domain;
using BlueprintsNet.Core.Models.Classes;
using BlueprintsNet.Generator.Generators;
using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Generator.IntegrationTests;

[TestFixture]
public class BlueprintGenerationIntegrationTests
{
    private IBlueprintGenerator _blueprintGenerator;

    [SetUp]
    public void SetUp()
    {
        _blueprintGenerator = new BlueprintGenerator();
    }

    [Test]
    public void Generating_blueprint_Should_create_correct_code()
    {
        // Arrange
        var method = new Method("MethodTest", AccessModifier.Public);
        var blueprint = new BPMethodIn(method);
        blueprint.Method
                 .AddParameter(new Parameter("boolIn", typeof(Bool)));
        blueprint.Method
                 .AddParameter(new Parameter("stringIn", typeof(Core.Models.Blueprints.String)));
        blueprint.Method
                 .AddParameter(new Parameter("intIn", typeof(Integer)));
        var ifStatement = new BPIf();
        var plusStatement = new BPPlus();
        var field = new BPField(new Field("intField", AccessModifier.Public, "int"));
        ifStatement.Condition.Previous = blueprint.InValues[0];
        plusStatement.In1.Previous = blueprint.InValues[2];
    }
}

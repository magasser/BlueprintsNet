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
        ifStatement.OutTrue.Next = toUpStatement.In;
        ifStatement.OutFalse.Next = addStrStatement.In;
        toUpStatement.Out.Next = testConstructorIf.In;
        addStrStatement.Out.Next = testConstructorElse.In;
        testConstructorIf.Out.Next = returnIf.In;
        testConstructorElse.Out.Next = returnElse.In;

        // Act
        var result = _blueprintGenerator.Generate(method.Start);

        // Assert
    }
}

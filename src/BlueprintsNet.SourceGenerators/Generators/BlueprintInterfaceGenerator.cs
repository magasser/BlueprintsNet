using System;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace BlueprintsNet.SourceGenerators
{
    [Generator]
    public class BlueprintInterfaceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var blueprints = ((BlueprintFinder)context.SyntaxReceiver).Blueprints;

            var sourceBuilder = new StringBuilder();

            sourceBuilder.Append(
@"using System;

using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Core
{
    public interface IBlueprintGenerator
    {
        string Generate(IBlueprint bp);

");

            blueprints.ForEach(blueprint => sourceBuilder.Append("        ")
                                                         .Append("string Generate(")
                                                         .Append(blueprint.Identifier.ValueText)
                                                         .AppendLine(" bp);")
                                                         .Append(Environment.NewLine));

            sourceBuilder.Append(
@"        void Reset();
    }
}");

            context.AddSource("IBlueprintGenerator.g.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new BlueprintFinder());

        #if DEBUG
            /*if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }*/
#endif
        }
    }
}

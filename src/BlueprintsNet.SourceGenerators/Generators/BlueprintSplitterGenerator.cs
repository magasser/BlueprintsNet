using System;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace BlueprintsNet.SourceGenerators
{
    [Generator]
    public class BlueprintSplitterGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var blueprints = ((BlueprintFinder)context.SyntaxReceiver).Blueprints;

            var sourceBuilder = new StringBuilder();

            sourceBuilder.Append(
@"using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Generator.Generators
{
    internal partial class BlueprintGenerator : BlueprintGeneratorBase
    {
        public override string Generate(IBlueprint bp)
        {
            return bp switch
            {
");

            blueprints.ForEach(blueprint => sourceBuilder.Append("                ")
                                                .Append(blueprint.Identifier.ValueText)
                                                .Append("=> Generate((")
                                                .Append(blueprint.Identifier.ValueText)
                                                .Append(")bp),")
                                                .Append(Environment.NewLine));
            sourceBuilder.Append(
@"                _ => throw new NotSupportedException($""The blueprint type {bp.GetType().Name} is not supported."")
            };
        }
    }
}");

            context.AddSource("BlueprintGeneratorSplitter.g.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
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

using System;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace BlueprintsNet.SourceGenerators.Generators
{
    [Generator]
    public class BlueprintGeneratorBaseGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var blueprints = ((BlueprintFinder)context.SyntaxReceiver).Blueprints;

            var sourceBuilder = new StringBuilder();

            sourceBuilder.Append(
@"using System;

using Light.GuardClauses;

using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Core
{
    public abstract class BlueprintGeneratorBase : IBlueprintGenerator
    {
        public string Generate(IBlueprint bp)
        {
            bp.MustNotBeNull();

            return bp.Generate(this);
        }

");

            blueprints.ForEach(blueprint => sourceBuilder.Append("        ")
                                                .Append("public abstract string Generate(")
                                                .Append(blueprint.Identifier.ValueText)
                                                .Append(" bp);")
                                                .Append(Environment.NewLine));

            sourceBuilder.Append(
@"    }
}");

            context.AddSource("BlueprintGeneratorBase.g.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
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

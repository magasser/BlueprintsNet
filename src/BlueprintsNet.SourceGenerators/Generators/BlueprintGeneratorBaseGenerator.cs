using System;
using System.Collections.Generic;
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
@"using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Generator.Generators
{
    internal abstract class BlueprintGeneratorBase : IBlueprintGenerator
    {
        public abstract string Generate(IBlueprint bp);
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
        }
    }
}

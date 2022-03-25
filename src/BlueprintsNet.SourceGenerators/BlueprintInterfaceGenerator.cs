using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BlueprintsNet.SourceGenerators
{
    [Generator]
    internal class BlueprintInterfaceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var blueprints = ((BlueprintFinder)context.SyntaxReceiver).Blueprints;

            var sourceBuilder = new StringBuilder();

            sourceBuilder.Append(
    @"using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Core
{
    public interface IBlueprintGenerator
    {
");

            blueprints.ForEach(blueprint =>
            {
                sourceBuilder.AppendLine($"        string Generate({blueprint.Identifier.ValueText} bp);");
                sourceBuilder.Append(Environment.NewLine);
            });

            sourceBuilder.Append(
    @"    }
}");

            context.AddSource($"IBlueprintGenerator.g.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new BlueprintFinder());

#if DEBUG
            /*if (false && !Debugger.IsAttached)
            {
                Debugger.Launch();
            }*/
#endif
        }

        public class BlueprintFinder : ISyntaxReceiver
        {
            public List<ClassDeclarationSyntax> Blueprints { get; } = new();

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if (syntaxNode is null)
                {
                    throw new ArgumentNullException(nameof(syntaxNode));
                }

                if (syntaxNode is ClassDeclarationSyntax declarationSyntax)
                {
                    var isAbstract = declarationSyntax.Modifiers
                                         .FirstOrDefault(token => token.ValueText == "abstract")
                        != default;
                    var isBlueprint = declarationSyntax.BaseList?.Types
                                        .FirstOrDefault(type =>
                                        {
                                            var identifierText = ((IdentifierNameSyntax)type.Type)?.Identifier.ValueText;

                                            return identifierText == "IBlueprint" || identifierText.StartsWith("BP");
                                        })
                        != null;
                    var t = declarationSyntax.Identifier.ValueText
                                .StartsWith("BP");
                    if (isBlueprint && !isAbstract)
                    {
                        Blueprints.Add(declarationSyntax);
                    }
                }
            }
        }
    }
}

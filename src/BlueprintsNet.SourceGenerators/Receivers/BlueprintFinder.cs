using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BlueprintsNet.SourceGenerators;

internal class BlueprintFinder : ISyntaxReceiver
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
            if (isBlueprint && !isAbstract)
            {
                Blueprints.Add(declarationSyntax);
            }
        }
    }
}

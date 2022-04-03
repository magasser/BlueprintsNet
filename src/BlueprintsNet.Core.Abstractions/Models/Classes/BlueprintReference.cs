
namespace BlueprintsNet.Core.Models.Classes;

public record BlueprintReference(Guid Id,
                                 IBlueprint Blueprint,
                                 IEntryPoint Parent);

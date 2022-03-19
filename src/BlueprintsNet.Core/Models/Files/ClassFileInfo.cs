
namespace BlueprintsNet.Core.Models.Files;

internal record ClassFileInfo
{
    public string Extension { get; init; } = "bnc";

    public Version Version { get; init; } = new Version(0, 1, 0);
}

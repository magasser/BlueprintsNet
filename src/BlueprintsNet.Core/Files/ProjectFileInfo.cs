
namespace BlueprintsNet.Core.Files;

internal record ProjectFileInfo
{
    public string Extension { get; init; } = "bnproj";

    public Version Version { get; init; } = new Version(0, 1, 0);
}


namespace BlueprintsNet.Core.Models.Files;

internal record ClassFileInfo
{
    public string Extension { get; } = "bpc";

    public Version Version { get; } = new Version(0, 1, 0);
}

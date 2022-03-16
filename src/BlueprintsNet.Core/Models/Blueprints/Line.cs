
namespace BlueprintsNet.Core.Models.Blueprints;

public class Line
{
    public Line(INode start, INode end)
    {
        Start = start.MustNotBeNull();
        End = end.MustNotBeNull();

        FixPositions = new List<Position>();
    }

    public INode Start { get; }

    public INode End { get; }

    List<Position> FixPositions { get; }
}

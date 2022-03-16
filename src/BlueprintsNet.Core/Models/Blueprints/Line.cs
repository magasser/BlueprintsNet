
namespace BlueprintsNet.Core.Models.Blueprints;

public class Line
{
    public Line(Position start, Position end)
    {
        Start = start.MustNotBeNull();
        End = end.MustNotBeNull();

        FixPositions = new List<Position>();
    }

    public Position Start { get; }

    public Position End { get; }

    List<Position> FixPositions { get; }
}

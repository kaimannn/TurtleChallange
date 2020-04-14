using TurtleChallenge.App.Entities;

namespace TurtleChallenge.App.Interfaces
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }

        bool IsValid(Board board);
    }
}

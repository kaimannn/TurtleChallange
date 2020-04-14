using System.Collections.Generic;
using TurtleChallenge.App.Entities;

namespace TurtleChallenge.App.Interfaces
{
    public interface IBoard
    {
        Position[,] Cells { get; set; }
        int SizeX { get; set; }
        int SizeY { get; set; }

        void Initialize(IEnumerable<Mine> mines, Exit exit, int sizeX, int sizeY);
        void Initialize(IEnumerable<Mine> mines, Exit exit);
        bool IsValid();
    }
}
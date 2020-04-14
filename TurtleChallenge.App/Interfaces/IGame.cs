using System.Collections.Generic;
using TurtleChallenge.App.Entities;

namespace TurtleChallenge.App.Interfaces
{
    public interface IGame
    {
        Board Board { get; set; }
        Exit Exit { get; set; }
        IEnumerable<Mine> Mines { get; set; }
        Turtle Turtle { get; set; }

        bool IsMovementAllowed(Board board, Turtle turtle);
        bool IsGameOver();
        void Validate();
    }
}
using System;
using System.Collections.Generic;
using TurtleChallenge.App.Interfaces;

namespace TurtleChallenge.App.Entities
{
    public class Game : IGame
    {
        public Board Board { get; set; }
        public Turtle Turtle { get; set; }
        public Exit Exit { get; set; }
        public IEnumerable<Mine> Mines { get; set; }

        public bool IsGameOver()
        {
            var cell = Board.Cells[Turtle.X, Turtle.Y];
            if (cell is Mine || cell is Exit)
                return true;

            return false;
        }

        public bool IsMovementAllowed(Board board, Turtle turtle)
        {
            var tmpTurtle = new Turtle
            {
                X = turtle.X,
                Y = turtle.Y,
                Direction = turtle.Direction
            };
            
            tmpTurtle.Move();

            return tmpTurtle.IsValid(board);
        }

        public void Validate()
        {
            ValidateBoard();
            ValidateTurtle();
            ValidateMines();
            ValidateExit();
        }

        private void ValidateBoard()
        {
            if (Board == null)
                throw new ArgumentNullException("The json board format is not correct.");

            if (!Board.IsValid())
                throw new ArgumentOutOfRangeException($"Board size [{Board.SizeX}, {Board.SizeY}] is not valid.");
        }

        private void ValidateTurtle()
        {
            if (Turtle == null)
                throw new ArgumentNullException("The json turtle format is not correct.");

            if(!Turtle.IsValid(Board))
                throw new ArgumentOutOfRangeException($"The turtle position [{Turtle.X}, {Turtle.Y}] is not valid.");
        }

        private void ValidateMines()
        {
            if (Mines == null)
                throw new ArgumentNullException("The json mines format is not correct.");

            foreach (Mine mine in Mines)
            {
                if (!mine.IsValid(Board))
                    throw new ArgumentOutOfRangeException($"The mine position [{mine.X}, {mine.Y}] is not valid.");
            }
        }

        private void ValidateExit()
        {
            if (Exit == null)
                throw new ArgumentNullException("The json exit cell format is not correct.");

            if (!Exit.IsValid(Board))
                throw new ArgumentOutOfRangeException($"The exit position [{Exit.X}, {Exit.Y}] is not valid.");
        }
    }
}

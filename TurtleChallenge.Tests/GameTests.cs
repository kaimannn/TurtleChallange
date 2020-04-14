using NUnit.Framework;
using System.Collections.Generic;
using TurtleChallenge.App.Entities;

namespace TurtleChallenge.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        private const int BoardSizeX = 5;
        private const int BoardSizeY = 5;
        private const int MinePosX = 1;
        private const int MinePosY = 1;
        private const int ExitPosX = 2;
        private const int ExitPosY = 2;

        [SetUp]
        public void Setup()
        {
            _game = new Game
            {
                Board = new Board
                {
                    SizeX = BoardSizeX,
                    SizeY = BoardSizeY,
                    Cells = new Position[BoardSizeX, BoardSizeY]
                },
                Mines = new List<Mine>
                {
                    new Mine
                    {
                        X = MinePosX,
                        Y = MinePosY
                    }
                },
                Exit = new Exit
                {
                    X = ExitPosX,
                    Y = ExitPosY
                },
                Turtle = new Turtle
                {
                    X = 0,
                    Y = 0
                }
            };

            _game.Board.Initialize(_game.Mines, _game.Exit);
        }

        [Test]
        public void CheckIfGameOver_IfCellIsNotMineAndNotExit_ReturnFalse()
        {
            var gameOver = _game.IsGameOver();

            Assert.IsFalse(gameOver);
        }

        [Test]
        public void CheckIfGameOver_IfCellIsMine_ReturnTrue()
        {
            _game.Turtle.X = MinePosX;
            _game.Turtle.Y = MinePosY;

            var gameOver = _game.IsGameOver();

            Assert.IsTrue(gameOver);
        }

        [Test]
        public void CheckIfGameOver_IfCellIsExit_ReturnTrue()
        {
            _game.Turtle.X = ExitPosX;
            _game.Turtle.Y = ExitPosY;

            var gameOver = _game.IsGameOver();

            Assert.IsTrue(gameOver);
        }
    }
}
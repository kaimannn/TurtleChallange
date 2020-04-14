using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TurtleChallenge.App.Entities;

namespace TurtleChallenge.Tests
{
    [TestFixture]
    public class BoardTests
    {
        private Board _board;
        private IEnumerable<Mine> _mines;
        private Exit _exit;

        private const int SizeX = 6;
        private const int SizeY = 5;
        private const int MinePosX = 1;
        private const int MinePosY = 1;
        private const int ExitPosX = 2;
        private const int ExitPosY = 2;

        [SetUp]
        public void Setup()
        {
            _board = new Board
            {
                SizeX = SizeX,
                SizeY = SizeY,
                Cells = new Position[SizeX, SizeY]
            };

            _mines = new List<Mine>
            {
                new Mine
                {
                    X = MinePosX,
                    Y = MinePosY
                }
            };

            _exit = new Exit
            {
                X = ExitPosX,
                Y = ExitPosY
            };
        }

        [Test]
        public void Initialize_IfThereIsAtLeastOneMine_BoardIsOk()
        {
            _board.Initialize(_mines, _exit);

            bool mineExists = ExistsCell(typeof(Mine));

            Assert.IsTrue(mineExists);
        }

        [Test]
        public void Initialize_IfThereIsOneExit_BoardIsOk()
        {
            _board.Initialize(_mines, _exit);

            bool exitExists = ExistsCell(typeof(Exit));

            Assert.IsTrue(exitExists);
        }

        [Test]
        public void Initialize_IfThereAreNoMinesOrExit_BoardIsNotOk()
        {
            _mines = new List<Mine>();

            _board.Initialize(_mines, _exit);

            bool mineExists = ExistsCell(typeof(Mine));

            Assert.IsFalse(mineExists);
        }

        private bool ExistsCell(Type type)
        {
            for (int x = 0; x < _board.SizeX; x++)
            {
                for (int y = 0; y < _board.SizeY; y++)
                {
                    if (type == _board.Cells[x, y].GetType())
                        return true;
                }
            }

            return false;
        }

        [Test]
        public void Initialize_WhenErrorOccurs_ThrowsException()
        {
            var ex = Assert.Throws<Exception>(() => _board.Initialize(null, null));

            Assert.That(ex.Message, Is.EqualTo("Error ocurred while filling the board."));
        }

        [Test]
        public void Validate_IfBoardSizeIsValid_ReturnsTrue()
        {
            bool isValid = _board.IsValid();

            Assert.IsTrue(isValid);
        }

        [Test]
        public void Validate_IfBoardSizeXIsNotValid_ReturnsFalse()
        {
            _board.SizeX = 0;

            bool isValid = _board.IsValid();

            Assert.IsFalse(isValid);
        }

        [Test]
        public void Validate_IfBoardSizeYIsNotValid_ReturnsFalse()
        {
            _board.SizeY = 0;

            bool isValid = _board.IsValid();

            Assert.IsFalse(isValid);
        }
    }
}
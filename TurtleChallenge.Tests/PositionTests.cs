using NUnit.Framework;
using System;
using TurtleChallenge.App.Entities;

namespace TurtleChallenge.Tests
{
    [TestFixture]
    public class PositionTests
    {
        private Board _board;
        private Position _position;

        private const int SizeX = 5;
        private const int SizeY = 5;
        private const int PositionX = 2;
        private const int PositionY = 2;

        [SetUp]
        public void Setup()
        {
            _board = new Board
            {
                SizeX = SizeX,
                SizeY = SizeY,
                Cells = new Position[SizeX, SizeY]
            };

            _position = new Position
            {
                X = PositionX,
                Y = PositionY
            };
        }

        [Test]
        public void IsValid_IfPositionIsValid_ReturnsTrue()
        {
            Assert.IsTrue(_position.IsValid(_board));
        }

        [Test]
        public void IsValid_IfMinimumXIsNotValid_ReturnsFalse()
        {
            _position.X = -1;

            Assert.IsFalse(_position.IsValid(_board));
        }

        [Test]
        public void IsValid_IfMaximumXIsNotValid_ReturnsFalse()
        {
            _position.X = _board.SizeX;

            Assert.IsFalse(_position.IsValid(_board));
        }

        [Test]
        public void IsValid_IfMinimumYIsNotValid_ReturnsFalse()
        {
            _position.Y = -1;

            Assert.IsFalse(_position.IsValid(_board));
        }

        [Test]
        public void IsValid_IfMaximumYIsNotValid_ReturnsFalse()
        {
            _position.Y = _board.SizeY;

            Assert.IsFalse(_position.IsValid(_board));
        }
    }
}
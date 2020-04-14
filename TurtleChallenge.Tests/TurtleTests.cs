using NUnit.Framework;
using TurtleChallenge.App.Entities;

namespace TurtleChallenge.Tests
{
    [TestFixture]
    public class TurtleTests
    {
        private Turtle _turtle;

        private const int TurtlePosX = 1;
        private const int TurtlePosY = 1;

        [SetUp]
        public void Setup()
        {
            _turtle = new Turtle
            {
                X = TurtlePosX,
                Y = TurtlePosY,
            };
        }

        [Test]
        public void Rotate_IfDirectionIsEast_ReturnNord()
        {
            _turtle.Direction = App.Enums.Direction.East;

            _turtle.Rotate();

            Assert.That(_turtle.Direction == App.Enums.Direction.North);
        }
        
        [Test]
        public void Rotate_IfDirectionIsNorth_ReturnWest()
        {
            _turtle.Direction = App.Enums.Direction.North;

            _turtle.Rotate();

            Assert.That(_turtle.Direction == App.Enums.Direction.West);
        }

        [Test]
        public void Rotate_IfDirectionIsWest_ReturnSouth()
        {
            _turtle.Direction = App.Enums.Direction.West;

            _turtle.Rotate();

            Assert.That(_turtle.Direction == App.Enums.Direction.South);
        }

        [Test]
        public void Rotate_IfDirectionIsSouth_ReturnEast()
        {
            _turtle.Direction = App.Enums.Direction.South;

            _turtle.Rotate();

            Assert.That(_turtle.Direction == App.Enums.Direction.East);
        }

        [Test]
        public void Move_IfDirectionIsEast_DecreaseX()
        {
            _turtle.Direction = App.Enums.Direction.East;

            _turtle.Move();

            Assert.That(_turtle.X == TurtlePosX - 1);
        }

        [Test]
        public void Move_IfDirectionIsNorth_IncreaseY()
        {
            _turtle.Direction = App.Enums.Direction.North;

            _turtle.Move();

            Assert.That(_turtle.Y == TurtlePosY + 1);
        }

        [Test]
        public void Move_IfDirectionIsWest_IncreaseX()
        {
            _turtle.Direction = App.Enums.Direction.West;

            _turtle.Move();

            Assert.That(_turtle.X == TurtlePosX + 1);
        }

        [Test]
        public void Move_IfDirectionIsSouth_DecreaseY()
        {
            _turtle.Direction = App.Enums.Direction.South;

            _turtle.Move();

            Assert.That(_turtle.Y == TurtlePosY - 1);
        }
    }
}
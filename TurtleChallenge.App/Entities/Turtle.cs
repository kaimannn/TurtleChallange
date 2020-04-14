using System;
using TurtleChallenge.App.Interfaces;

namespace TurtleChallenge.App.Entities
{
    public partial class Turtle : Position, ITurtle
    {
        public Enums.Direction Direction { get; set; }

        public void Rotate()
        {
            if (Direction == Enums.Direction.East)
                Direction = Enums.Direction.North;

            else if (Direction == Enums.Direction.North)
                Direction = Enums.Direction.West;

            else if (Direction == Enums.Direction.West)
                Direction = Enums.Direction.South;

            else if (Direction == Enums.Direction.South)
                Direction = Enums.Direction.East;
        }

        public void Move()
        {
            if (Direction == Enums.Direction.East)
                X--;

            else if (Direction == Enums.Direction.North)
                Y++;

            else if (Direction == Enums.Direction.West)
                X++;

            else if (Direction == Enums.Direction.South)
                Y--;

        }
    }
}

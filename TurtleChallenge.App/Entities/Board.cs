using System;
using System.Collections.Generic;
using TurtleChallenge.App.Interfaces;

namespace TurtleChallenge.App.Entities
{
    public class Board : IBoard
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Position[,] Cells { get; set; }

        public void Initialize(IEnumerable<Mine> mines, Exit exit, int sizeX, int sizeY) => Fill(mines, exit, sizeX, sizeY);

        public void Initialize(IEnumerable<Mine> mines, Exit exit) => Fill(mines, exit, SizeX, SizeY);

        private void Fill(IEnumerable<Mine> mines, Exit exit, int sizeX, int sizeY)
        {
            try
            {
                Cells = new Position[sizeX, sizeY];

                for (int x = 0; x < sizeX; x++)
                {
                    for (int y = 0; y < sizeY; y++)
                        Cells[x, y] = new Position();
                }

                foreach (var mine in mines)
                    Cells[mine.X, mine.Y] = new Mine();

                Cells[exit.X, exit.Y] = new Exit();
            }
            catch (Exception ex)
            {
                throw new Exception("Error ocurred while filling the board.", ex);
            }
        }

        public bool IsValid() => SizeX > 0 && SizeY > 0;
    }
}

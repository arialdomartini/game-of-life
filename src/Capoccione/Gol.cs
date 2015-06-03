using System.Collections.Generic;
using System;

namespace Capoccione
{
    public class Gol
    {
        public List<Cell> Neighbors(Cell cell)
        {
            return new List<Cell>{
                new Cell(cell.X-1, cell.Y-1),
                new Cell(cell.X, cell.Y-1),
                new Cell(cell.X+1, cell.Y-1),
                new Cell(cell.X-1, cell.Y),
                new Cell(cell.X+1, cell.Y),
                new Cell(cell.X-1, cell.Y+1),
                new Cell(cell.X, cell.Y+1),
                new Cell(cell.X+1, cell.Y+1),
            };
        }
    }
}

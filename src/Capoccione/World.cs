using System.Collections.Generic;
using System;
using System.IO;

namespace Capoccione
{

    public class World
    {
        List<Cell> _cells;

        public World(List<Cell> cells)
        {
            _cells = cells;
            
        }

        public void Evolve()
        {
            _cells = new List<Cell>();
        }

        public int CountNeighbors(Cell cell)
        {
            return cell.Neighbors().RemoveAll(Contains);
        }

        public bool Contains(Cell cell)
        {
            return _cells.Contains(cell);
        }

        public bool ShouldDie(Cell cell)
        {
            return this.CountNeighbors(cell) < 3;
        }
    }
}

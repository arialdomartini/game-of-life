using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

namespace Capoccione
{

    public class World
    {
        List<Cell> _cells;

        public override bool Equals(object obj)
        {
            var other = obj as World;
            foreach(var cell in _cells)
            {
                if(!other.Contains(cell))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public World(List<Cell> cells)
        {
            _cells = cells;
            
        }

        public void Evolve()
        {
            var newGeneration = new List<Cell>();
            foreach(var cell in _cells)
            {
                if(!ShouldDie(cell))
                {
                    newGeneration.Add(cell);    
                }
            }

            foreach(var cell in _cells)
            {
                foreach(var neighbor in cell.Neighbors())
                {
                    if(ShouldGetToLife(neighbor))
                    {
                        newGeneration.Add(neighbor);
                    }

                }
            }
            _cells = newGeneration;
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
            var neighbors = CountNeighbors(cell);
            return neighbors != 2;
        }

        public bool ShouldGetToLife(Cell cell)
        {
            return CountNeighbors(cell) == 3;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace Capoccione
{
    public static class World
    {
        public static List<Cell> Evolve(List<Cell> generation)
        {
            var newGeneration = new List<Cell>();

            var survivors = from cell in generation where !ShouldDie(cell, generation) select cell;

            var newBorn = from neighbors in (from cell in generation
                select cell.Neighbors()) from neighbor in neighbors
                    where ShouldGetToLife(neighbor, generation) && !newGeneration.Contains(neighbor)
                select neighbor;
            return survivors.Union(newBorn).ToList();
        }

        public static int CountNeighbors(Cell cell, List<Cell> generation)
        {
            return cell.Neighbors().RemoveAll(c => World.Contains(c, generation));
        }

        public static bool Contains(Cell cell, List<Cell> generation)
        {
            return generation.Contains(cell);
        }

        public static bool ShouldDie(Cell cell, List<Cell> generation)
        {
            return CountNeighbors(cell, generation) != 2;
        }

        public static bool ShouldGetToLife(Cell cell, List<Cell> generation)
        {
            return CountNeighbors(cell, generation) == 3;
        }
    }
}

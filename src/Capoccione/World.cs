using System.Collections.Generic;

namespace Capoccione
{
    public static class World
    {
        public static List<Cell> Evolve(List<Cell> generation)
        {
            var newGeneration = new List<Cell>();

            foreach(var cell in generation)
            {
                if(!ShouldDie(cell, generation))
                {
                    newGeneration.Add(cell);    
                }
                foreach(var neighbor in cell.Neighbors())
                {
                    if(ShouldGetToLife(neighbor, generation) && ! newGeneration.Contains(neighbor))
                    {
                        newGeneration.Add(neighbor);
                    }
                }
            }
           return newGeneration;
        }

        public static int CountAliveNeighbors(Cell cell, List<Cell> generation)
        {
            return cell.Neighbors().RemoveAll(c => generation.Contains(c));
        }


        public static bool ShouldDie(Cell cell, List<Cell> generation)
        {
            return CountAliveNeighbors(cell, generation) != 2;
        }

        public static bool ShouldGetToLife(Cell cell, List<Cell> generation)
        {
            return CountAliveNeighbors(cell, generation) == 3;
        }
    }
}

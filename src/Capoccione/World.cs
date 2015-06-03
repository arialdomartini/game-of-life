using System.Collections.Generic;
using System;

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
            }

            foreach(var cell in generation)
            {
                foreach(var neighbor in cell.Neighbors())
                {
                    if(ShouldGetToLife(neighbor, generation))
                    {
                        if( ! newGeneration.Contains(neighbor))
                        {
                            newGeneration.Add(neighbor);
                        }
                    }

                }
            }
            return newGeneration;
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
            var neighbors = World.CountNeighbors(cell, generation);
            return neighbors != 2;
        }

        public static bool ShouldGetToLife(Cell cell, List<Cell> generation)
        {
            return CountNeighbors(cell, generation) == 3;
        }
    }
}

using System.Collections.Generic;


namespace Capoccione
{
	public class Cell
    {
        public int X {
            get;
            private set;
        }
        public int Y {
            get;
            private set;
        }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public List<Cell> Neighbors()
        {
            return new List<Cell>{
                new Cell(X-1, Y-1),
                new Cell(X, Y-1),
                new Cell(X+1, Y-1),
                new Cell(X-1, Y),
                new Cell(X+1, Y),
                new Cell(X-1, Y+1),
                new Cell(X, Y+1),
                new Cell(X+1, Y+1),
            };
        }
   
        public override bool Equals(object obj)
        {
            var other = obj as Cell;
            return other.X == X && other.Y == Y;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
	}

}

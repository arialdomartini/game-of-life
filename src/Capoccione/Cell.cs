
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

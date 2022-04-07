using System;

namespace Version1
{
    [Serializable]
    public class Vector2Int
    {
        public int X;
        public int Y;

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Vector2Int operator +(Vector2Int value1, Vector2Int value2)
        {
            return new Vector2Int(value1.X + value2.X, value1.Y + value2.Y);
        }
        public static Vector2Int operator -(Vector2Int value1, Vector2Int value2)
        {
            return new Vector2Int(value1.X - value2.X, value1.Y - value2.Y);
        }
        public static Vector2Int operator /(Vector2Int value1, int value2)
        {
            return new Vector2Int(value1.X / value2, value1.Y / value2);
        }
        public static Vector2Int operator *(Vector2Int value1, int value2)
        {
            return new Vector2Int(value1.X * value2, value1.Y * value2);
        }
        public static bool operator ==(Vector2Int value1, Vector2Int value2)
        {
            return value1.X == value2.X && value1.Y == value2.Y;
        }

        public static bool operator !=(Vector2Int value1, Vector2Int value2)
        {
            return !(value1 == value2);
        }

        public override string ToString()
        {
            return $"x = {X} y = {Y}";
        }
        protected bool Equals(Vector2Int other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vector2Int) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static Vector2Int Up => new Vector2Int(0, 1);
        public static Vector2Int Down => new Vector2Int(0, -1);
        public static Vector2Int Left => new Vector2Int(-1, 0);
        public static Vector2Int Right => new Vector2Int(1, 0);
    }
}
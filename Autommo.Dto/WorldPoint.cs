namespace Autommo.Dto
{
    public class WorldPoint
    {
        public decimal X { get; set; }

        public decimal Y { get; set; }

        public decimal Z { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null ||
                GetType() != obj.GetType())
                return false;

            var other = (WorldPoint)obj;
            return other.X == X && other.Y == Y && other.Z == Z;
        }

        public override int GetHashCode()
        {
            return (X + Y + Z).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", X, Y, Z);
        }
    }
}
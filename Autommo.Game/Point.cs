namespace Autommo.Game
{
    public class Point
    {
        public Point(decimal x, decimal y, decimal z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public decimal X { get; private set; }
        public decimal Y { get; private set; }
        public decimal Z { get; private set; }
    }
}
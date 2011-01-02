namespace Autommo.Game
{
    public class Point
    {
        public Point(Length x, Length y, Length z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Length X { get; private set; }
        public Length Y { get; private set; }
        public Length Z { get; private set; }
    }
}
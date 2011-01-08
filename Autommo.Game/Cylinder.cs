namespace Autommo.Game
{
    public class Cylinder
    {
        public Cylinder(Point baseCentre, Length height)
        {
            BaseCentre = baseCentre;
            Height = height;
        }

        public Point BaseCentre { get; private set; }

        public Length Height { get; private set; }
    }
}
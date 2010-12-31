namespace Autommo.Game
{
    public class Cylinder
    {
        public Cylinder(Point baseCentre, decimal height)
        {
            BaseCentre = baseCentre;
            Height = height;
        }

        public Point BaseCentre { get; private set; }
        public decimal Height { get; private set; }
    }
}
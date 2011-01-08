namespace Autommo.Game
{
    public class UnitPosition
    {
        public UnitPosition(Cylinder location, decimal orientation)
        {
            Location = location;
            Orientation = orientation;
        }

        public Cylinder Location { get; private set; }

        public decimal Orientation { get; private set; }
    }
}
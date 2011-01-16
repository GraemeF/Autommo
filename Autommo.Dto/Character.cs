namespace Autommo.Dto
{
    using System;

    public class Character
    {
        public UnitPosition Position { get; set; }

        public string Status { get; set; }

        public string Name { get; set; }
    }

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
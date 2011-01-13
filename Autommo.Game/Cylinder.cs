namespace Autommo.Game
{
    using Autommo.Dto;

    public class Cylinder
    {
        public Cylinder(WorldPoint baseCentre, Length height)
        {
            BaseCentre = baseCentre;
            Height = height;
        }

        public WorldPoint BaseCentre { get; private set; }

        public Length Height { get; private set; }
    }
}
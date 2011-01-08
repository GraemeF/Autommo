namespace Autommo.Game
{
    using Autommo.Game.Interfaces;

    using ReactiveXaml;

    public class World : IWorld
    {
        public World()
        {
            Units = new ReactiveCollection<IUnit>();
        }

        public ReactiveCollection<IUnit> Units { get; private set; }
    }
}
using Autommo.Game.Interfaces;
using ReactiveXaml;

namespace Autommo.Game
{
    public class World : IWorld
    {
        public World()
        {
            Units = new ReactiveCollection<IUnit>();
        }

        #region IWorld Members

        public ReactiveCollection<IUnit> Units { get; private set; }

        #endregion
    }
}
namespace Autommo.Game
{
    #region Using Directives

    using Autommo.Game.Interfaces;

    using ReactiveXaml;

    #endregion

    public class World : IWorld
    {
        public World()
        {
            Units = new ReactiveCollection<IUnit>();
            Characters = new ReactiveCollection<ICharacter>();
        }

        public ReactiveCollection<ICharacter> Characters { get; private set; }

        public ReactiveCollection<IUnit> Units { get; private set; }
    }
}
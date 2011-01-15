namespace Autommo.Game.Interfaces
{
    #region Using Directives

    using ReactiveXaml;

    #endregion

    public interface IWorld
    {
        ReactiveCollection<ICharacter> Characters { get; }

        ReactiveCollection<IUnit> Units { get; }
    }
}
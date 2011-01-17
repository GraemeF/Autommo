namespace Autommo.Game.Interfaces
{
    #region Using Directives

    using ReactiveUI;

    #endregion

    public interface IWorld
    {
        ReactiveCollection<ICharacter> Characters { get; }

        ReactiveCollection<IUnit> Units { get; }
    }
}
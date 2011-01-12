namespace Autommo.Game.Interfaces
{
    using ReactiveXaml;

    public interface IWorld
    {
        ReactiveCollection<IUnit> Units { get; }

        ReactiveCollection<ICharacter> Characters { get; }
    }
}
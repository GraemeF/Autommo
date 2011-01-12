namespace Autommo.Game.Interfaces
{
    public interface ICharacter : IUnit
    {
        CharacterId Id { get; }
    }
}
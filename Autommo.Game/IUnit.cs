namespace Autommo.Game
{
    public interface IUnit
    {
        UnitPosition Position { get; }
        Length MeleeRange { get; }
        Length VisibilityRange { get; }
    }
}
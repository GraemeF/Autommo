namespace Autommo.Game.Interfaces
{
    public interface IUnit
    {
        UnitPosition Position { get; }
        Length MeleeRange { get; }
        Length VisibilityRange { get; }
        Health Health { get; }
    }
}
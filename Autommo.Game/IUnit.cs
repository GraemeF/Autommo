namespace Autommo.Game
{
    public interface IUnit
    {
        UnitPosition Position { get; }
        decimal MeleeRange { get; }
        decimal VisibilityRange { get; }
    }
}
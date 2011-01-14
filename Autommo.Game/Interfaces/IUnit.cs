namespace Autommo.Game.Interfaces
{
    using System.ComponentModel;

    using Autommo.Dto;

    public interface IUnit : INotifyPropertyChanged
    {
        int Health { get; }

        decimal MeleeRange { get; }

        UnitPosition Position { get; }

        decimal VisibilityRange { get; }
    }
}
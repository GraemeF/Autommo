namespace Autommo.Game.Interfaces
{
    #region Using Directives

    using System.ComponentModel;

    using Autommo.Dto;

    #endregion

    public interface IUnit : INotifyPropertyChanged
    {
        int Health { get; }

        decimal MeleeRange { get; }

        UnitPosition Position { get; }

        decimal VisibilityRange { get; }
    }
}
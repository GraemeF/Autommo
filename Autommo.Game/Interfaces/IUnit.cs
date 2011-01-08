namespace Autommo.Game.Interfaces
{
    using System.ComponentModel;

    public interface IUnit : INotifyPropertyChanged
    {
        Health Health { get; }

        Length MeleeRange { get; }

        UnitPosition Position { get; }

        Length VisibilityRange { get; }
    }
}
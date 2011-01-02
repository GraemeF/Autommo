using System.ComponentModel;

namespace Autommo.Game.Interfaces
{
    public interface IUnit : INotifyPropertyChanged
    {
        UnitPosition Position { get; }
        Length MeleeRange { get; }
        Length VisibilityRange { get; }
        Health Health { get; }
    }
}
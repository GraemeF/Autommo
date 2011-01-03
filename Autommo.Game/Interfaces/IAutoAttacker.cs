using ReactiveXaml;

namespace Autommo.Game.Interfaces
{
    public interface IAutoAttacker : IReactiveNotifyPropertyChanged
    {
        Length MaxRange { get; }
        bool IsAttacking { get; }
        void Attack(IUnit target);
    }
}
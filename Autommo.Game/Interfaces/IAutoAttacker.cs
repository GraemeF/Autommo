using ReactiveXaml;

namespace Autommo.Game.Interfaces
{
    public interface IAutoAttacker : IReactiveNotifyPropertyChanged
    {
        IUnit Target { get; }
        Length MaxRange { get; }
        bool IsAttacking { get; }
        void Attack(IUnit target);
    }
}
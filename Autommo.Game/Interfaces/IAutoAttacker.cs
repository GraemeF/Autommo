namespace Autommo.Game.Interfaces
{
    using ReactiveXaml;

    public interface IAutoAttacker : IReactiveNotifyPropertyChanged
    {
        bool IsAttacking { get; }

        Length MaxRange { get; }

        IUnit Target { get; }

        void Attack(IUnit target);
    }
}
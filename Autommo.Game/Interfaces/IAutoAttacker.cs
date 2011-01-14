namespace Autommo.Game.Interfaces
{
    using ReactiveXaml;

    public interface IAutoAttacker : IReactiveNotifyPropertyChanged
    {
        bool IsAttacking { get; }

        decimal MaxRange { get; }

        IUnit Target { get; }

        void Attack(IUnit target);
    }
}
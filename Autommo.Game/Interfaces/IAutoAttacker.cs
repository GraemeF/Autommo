namespace Autommo.Game.Interfaces
{
    #region Using Directives

    using ReactiveUI;

    #endregion

    public interface IAutoAttacker : IReactiveNotifyPropertyChanged
    {
        bool IsAttacking { get; }

        decimal MaxRange { get; }

        IUnit Target { get; }

        void Attack(IUnit target);
    }
}
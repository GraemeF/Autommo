namespace Autommo.Game.Interfaces
{
    #region Using Directives

    using ReactiveXaml;

    #endregion

    public interface IAutoAttacker : IReactiveNotifyPropertyChanged
    {
        bool IsAttacking { get; }

        decimal MaxRange { get; }

        IUnit Target { get; }

        void Attack(IUnit target);
    }
}
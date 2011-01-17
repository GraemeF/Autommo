namespace Autommo.Game
{
    #region Using Directives

    using Autommo.Game.Interfaces;

    using ReactiveUI;

    #endregion

    public class MeleeAttacker : Model, 
                                 IAutoAttacker
    {
        private bool _IsAttacking;

        private decimal _MaxRange;

        private IUnit _Target;

        public bool IsAttacking
        {
            get { return _IsAttacking; }
            private set { this.RaiseAndSetIfChanged(x => x.IsAttacking, value); }
        }

        public decimal MaxRange
        {
            get { return _MaxRange; }
            private set { this.RaiseAndSetIfChanged(x => x.MaxRange, value); }
        }

        public IUnit Target
        {
            get { return _Target; }
            private set { this.RaiseAndSetIfChanged(x => x.Target, value); }
        }

        #region IAutoAttacker members

        public void Attack(IUnit target)
        {
            Target = target;
            IsAttacking = true;
        }

        #endregion
    }
}
namespace Autommo.Game
{
    #region Using Directives

    using System;
    using System.Linq;

    using Autommo.Dto;
    using Autommo.Game.Interfaces;

    using ReactiveXaml;

    #endregion

    public class Character : Model, 
                             ICharacter
    {
        private readonly CombatStatus _CombatStatus = CombatStatus.Idle;

        private readonly IAutoAttacker _meleeAttacker;

        private IUnit _Target;

        public Character(CharacterId id, IAutoAttacker meleeAttacker)
        {
            Id = id;
            _meleeAttacker = meleeAttacker;

            Subscriptions.Add(_meleeAttacker.
                                  ObservableForProperty(autoAttacker => autoAttacker.IsAttacking).
                                  Select(change => change.GetValue()).
                                  StartWith(_meleeAttacker.IsAttacking).
                                  Subscribe(isAttacking => CombatStatus = isAttacking
                                                                              ? CombatStatus.Fighting
                                                                              : CombatStatus.Idle));
            Subscriptions.Add(_meleeAttacker.
                                  ObservableForProperty(autoAttacker => autoAttacker.Target).
                                  Select(change => change.GetValue()).
                                  StartWith(_meleeAttacker.Target).
                                  Subscribe(target => Target = target));
        }

        public CombatStatus CombatStatus
        {
            get { return _CombatStatus; }
            private set { this.RaiseAndSetIfChanged(x => x.CombatStatus, value); }
        }

        public int Health
        {
            get { throw new NotImplementedException(); }
        }

        public CharacterId Id { get; private set; }

        public decimal MeleeRange
        {
            get { throw new NotImplementedException(); }
        }

        public UnitPosition Position
        {
            get { throw new NotImplementedException(); }
        }

        public IUnit Target
        {
            get { return _Target; }
            private set { this.RaiseAndSetIfChanged(x => x.Target, value); }
        }

        public decimal VisibilityRange
        {
            get { throw new NotImplementedException(); }
        }

        public void Attack(IUnit target)
        {
            _meleeAttacker.Attack(target);
        }
    }
}
using System;
using System.Linq;
using Autommo.Game.Interfaces;
using ReactiveXaml;

namespace Autommo.Game
{
    public class Player : Model, IPlayer
    {
        private readonly CombatStatus _CombatStatus = CombatStatus.Idle;
        private readonly IAutoAttacker _meleeAttacker;
        private IUnit _Target;

        public Player(IAutoAttacker meleeAttacker)
        {
            _meleeAttacker = meleeAttacker;

            Subscriptions.Add(_meleeAttacker.
                                  ObservableForProperty(autoAttacker => autoAttacker.IsAttacking).
                                  Select(change => change.Value).
                                  StartWith(_meleeAttacker.IsAttacking).
                                  Subscribe(isAttacking => CombatStatus = isAttacking
                                                                              ? CombatStatus.Fighting
                                                                              : CombatStatus.Idle));
        }

        public CombatStatus CombatStatus
        {
            get { return _CombatStatus; }
            private set { this.RaiseAndSetIfChanged(x => x.CombatStatus, value); }
        }

        public IUnit Target
        {
            get { return _Target; }
            private set { this.RaiseAndSetIfChanged(x => x.Target, value); }
        }

        #region IPlayer Members

        public UnitPosition Position
        {
            get { throw new NotImplementedException(); }
        }

        public Length MeleeRange
        {
            get { throw new NotImplementedException(); }
        }

        public Length VisibilityRange
        {
            get { throw new NotImplementedException(); }
        }

        public Health Health
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        public void Attack(IUnit target)
        {
            Target = target;
            CombatStatus = CombatStatus.Fighting;
        }
    }
}